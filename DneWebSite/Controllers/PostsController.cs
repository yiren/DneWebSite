using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.bulletin;
using DneWebSite.Models.common;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Webdiyer.WebControls.Mvc;
using DneWebSite.Helper;
using System.Security.Permissions;

namespace DneWebSite.Controllers
{

    [ClaimsAuthorize(ClaimType ="role", ClaimValue ="Post")]
    public class PostsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();
        private ApplicationUserManager _userManager;

        public PostsController()
        {
            
        }
        public PostsController(ApplicationUserManager userManager)
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
        // GET: Posts
        public ActionResult Index(int id=1)
        {
            
            var user = UserManager.FindByName(User.Identity.Name);
            ViewBag.User = user.FullName;

            var posts = db.Posts.AsNoTracking().Where(p => p.CreatedBy.Equals(user.FullName)&& p.IsDeleted!=true).OrderByDescending(p => p.PostDate).ToPagedList(id, 10);
            //分頁套件寫法
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PostList", posts);
            }
            return View(posts);
        }

        


        // GET: Posts/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            
            if (ModelState.IsValid)
            {
                #region 檔案上傳資料庫更新及實體檔案存檔
                List<PostFile> fileDetails = new List<PostFile>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        PostFile fileDetail = new PostFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId = Guid.NewGuid()
                        };
                       
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/post"),
                            fileDetail.FileId + fileDetail.Extension);

                        file.SaveAs(path);
                    }

                    

                    post.PostFiles = fileDetails;
                    
                    //post.CreatedBy=
                }
                #endregion

                var user = UserManager.FindByName(User.Identity.Name);
                post.PostDate = DateTime.Now.ToString("yyyy/MM/dd");
                post.PostId = Guid.NewGuid();
                post.CreatedBy = user.FullName;
                post.LastModifiedDate= DateTime.Now.ToString("yyyy/MM/dd");
                post.ModifiedBy = user.FullName;
                post.IsDeleted = false;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Post post = db.Posts.Include(p=>p.PostFiles).SingleOrDefault(p => p.PostId==id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId, Title, Content, Section, Category")]Post post)
        {
            var entry = db.Posts.Find(post.PostId);
            if (entry == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        PostFile fileDetail = new PostFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId = Guid.NewGuid(),
                            PostId = entry.PostId
                        };

                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/post"),
                            fileDetail.FileId + fileDetail.Extension);
                        file.SaveAs(path);
                        db.Entry(fileDetail).State = EntityState.Added;
                    }

                }
                var user = UserManager.FindByName(User.Identity.Name);


                //設定佈告紀錄相關屬性
                entry.PostId = post.PostId;
                entry.Section = post.Section;
                entry.Title = post.Title;
                entry.Category = post.Category;
                entry.Content = post.Content;
                entry.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                entry.ModifiedBy = user.FullName;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(p=>p.PostFiles).SingleOrDefault(p=>p.PostId==id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Post post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            var user = UserManager.FindByName(User.Identity.Name);
            post.IsDeleted = true;
            post.LastModifiedDate= DateTime.Now.ToString("yyyy/MM/dd");
            post.ModifiedBy = user.FullName;
            db.SaveChanges();
            return RedirectToAction("Index");
            

            
        }
        //管理者頁面，可以看到所有布告
        [ClaimsAuthorize(ClaimType = "role", ClaimValue = "PostAdmin")]
        public ActionResult Manage(int id = 1)
        {

            var meetings = db.Posts.AsNoTracking().Where(m => m.IsDeleted != true).OrderByDescending(m => m.PostDate).ToPagedList(id, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PostList", meetings);
            }
            return View("Index", meetings);
        }

        //管理者頁面可以看到所有被刪除的Post
        [ClaimsAuthorize(ClaimType = "role", ClaimValue = "PostAdmin")]
        public ActionResult DeletedList(int id = 1)
        {

            var meetings = db.Posts.AsNoTracking().Where(m => m.IsDeleted == true).OrderByDescending(m => m.PostDate).ToPagedList(id, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PostList", meetings);
            }
            return View("Index", meetings);
        }

        [AllowAnonymous]
        public FileResult Download(string p, string d)
        {
            return File(Path.Combine(Server.MapPath("~/upload/bulltin/post"), p),
                System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }


        //處理編輯頁面動態刪除附檔案
        [HttpPost]
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
                PostFile fileDetail = db.PostFiles.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.PostFiles.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/upload/bulltin/post"), fileDetail.FileId + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
