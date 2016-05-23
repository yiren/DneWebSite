using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.WANO;
using DneWebSite.Models.bulletin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Webdiyer.WebControls.Mvc;
using DneWebSite.Helper;
using System.IO;
using DneWebSite.Models.common;

namespace DneWebSite.Controllers
{

    [ClaimsAuthorize(ClaimType ="role", ClaimValue ="wano")]
    public class WanoController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();
        private ApplicationUserManager _userManager;

        public WanoController()
        {

        }
        public WanoController(ApplicationUserManager userManager)
        {

            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Items
        [AllowAnonymous]
        public ActionResult Index(int id=1)
        {   
            var items = db.Items.AsNoTracking().Where(i=>i.IsDeleted != true).OrderByDescending(p => p.LastModifiedDate).ToPagedList(id, 10);
            //分頁套件寫法
            if (Request.IsAjaxRequest())
            {
                return PartialView("_WanoList", items);
            }
            return View(items);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                List<ItemFile> fileDetails = new List<ItemFile>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ItemFile fileDetail = new ItemFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);
                        var path = Path.Combine(Server.MapPath("~/upload/wano"),
                            item.ItemId + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }
                
                item.ItemId = Guid.NewGuid();

                var user = UserManager.FindByName(User.Identity.Name);
                item.CreatedBy = user.FullName;
                item.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                item.ModifiedBy = user.FullName;
                item.ItemFiles = fileDetails;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //從DB中取得資料供View顯示
            Item item = db.Items.Include(i => i.ItemFiles).SingleOrDefault(i => i.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            var entry = db.Items.Include(i=>i.ItemFiles).SingleOrDefault(i=>i.ItemId==item.ItemId);
            if (entry == null)
            {
                return HttpNotFound();
            }
            //因為更要更新檔案，先把資料庫及實體檔案刪除
            for (int i=0;i<entry.ItemFiles.Count;i++)
            {
                var file = entry.ItemFiles.First();
                DeletePsyicalFile(file);
                db.ItemFiles.Remove(file);
            }

            if (ModelState.IsValid)
            {
                //取得Upload的檔案資訊
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    ItemFile fileDetail = new ItemFile()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        FileId = Guid.NewGuid(),
                        ItemId = entry.ItemId
                    };

                    var path = Path.Combine(Server.MapPath("~/upload/wano"),
                        item.ItemId + fileDetail.Extension);
                    file.SaveAs(path);
                    db.Entry(fileDetail).State = EntityState.Added;
                }

                //更新資料庫相關屬性
                var user = UserManager.FindByName(User.Identity.Name);
                entry.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                entry.ModifiedBy = user.FullName;
                entry.ItemName = item.ItemName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }
        [AllowAnonymous]
        public ActionResult Details(Guid? id)
        {
            var item = db.Items.Include(i=>i.ItemFiles).SingleOrDefault(i => i.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Include(i => i.ItemFiles).SingleOrDefault(i => i.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            //不刪除紀錄，僅Mark刪除，以便日後追蹤。
            Item item = db.Items.Find(id);
            item.IsDeleted = true;
            item.ModifiedBy = user.FullName;
            item.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public FileResult Download(string p, string d)
        {
            return File(Path.Combine(Server.MapPath("~/upload/wano"), p),
                System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        [HttpPost]
        //處理前端頁面動態刪除檔案
        public JsonResult DeleteFile(string fileId)
        {
            if (String.IsNullOrEmpty(fileId))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(fileId);
                ItemFile fileDetail = db.ItemFiles.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                //刪除實體檔案資料
                DeletePsyicalFile(fileDetail);
                //刪除Database紀錄
                db.ItemFiles.Remove(fileDetail);
                db.SaveChanges();

                
                
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        //刪除實體檔案方法
        private void DeletePsyicalFile(ItemFile fileDetail)
        {
            var path = Path.Combine(Server.MapPath("~/upload/wano"), fileDetail.ItemId + fileDetail.Extension);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
