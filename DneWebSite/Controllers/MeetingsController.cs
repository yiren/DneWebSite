using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.bulletin;
using DneWebSite.Models.dneMeeting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Webdiyer.WebControls.Mvc;
using System.IO;
using DneWebSite.Models.common;
using DneWebSite.Helper;
using System.Security.Claims;

namespace DneWebSite.Controllers
{
    [Authorize]
    public class MeetingsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();

        private ApplicationUserManager _userManager;

        public MeetingsController()
        {

        }
        public MeetingsController(ApplicationUserManager userManager)
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
        // GET: Meetings
        public ActionResult Index(int id=1)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            ViewBag.User = user.FullName;
            
            var meetings = db.Meetings.AsNoTracking().Where(m=>m.PostedBy.Equals(user.FullName)&& m.IsDeleted !=true).OrderByDescending(m => m.PostDate).ToPagedList(id, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MeetingList", meetings);
            }
            return View(meetings);
        }
        
        // GET: Meetings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Meeting entry)
        {
            if (ModelState.IsValid)
            {
                List<MeetingFile> fileDetails = new List<MeetingFile>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        MeetingFile fileDetail = new MeetingFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);
                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"),
                            fileDetail.FileId + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                var user = UserManager.FindByName(User.Identity.Name);
                entry.PostedBy = user.FullName;
                entry.PostDate = DateTime.Now.ToString("yyyy/MM/dd");
                entry.LastModifiedBy = user.FullName;
                entry.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                entry.MeetingFiles = fileDetails;
                entry.MeetingId = Guid.NewGuid();
                db.Meetings.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting dneMeeting = db.Meetings.Include(m=>m.MeetingFiles).SingleOrDefault(m=>m.MeetingId==id);
            if (dneMeeting == null)
            {
                return HttpNotFound();
            }
            return View(dneMeeting);
        }

        // POST: Meetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Meeting meeting)
        {

            var entry = db.Meetings.Find(meeting.MeetingId);
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
                        MeetingFile fileDetail = new MeetingFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId = Guid.NewGuid(),
                            MeetingId=entry.MeetingId
                        };

                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"),
                            fileDetail.FileId + fileDetail.Extension);
                        file.SaveAs(path);
                        db.Entry(fileDetail).State = EntityState.Added;
                    }

                }
                var user = UserManager.FindByName(User.Identity.Name);
                entry.MeetingTitle = meeting.MeetingTitle;
                entry.LastModifiedBy = user.FullName;
                entry.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Include(m => m.MeetingFiles).SingleOrDefault(m => m.MeetingId == id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Meeting meeting = db.Meetings.Find(id);
            meeting.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ClaimsAuthorize(ClaimType ="role", ClaimValue ="PostAdmin")]
        public ActionResult Manage(int id=1)
        {

            var meetings = db.Meetings.AsNoTracking().Where(m => m.IsDeleted != true).OrderByDescending(m => m.PostDate).ToPagedList(id, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MeetingList", meetings);
            }
            return View("Index", meetings);
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
            return File(Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"), p),
                System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

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
                var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"), fileDetail.FileId + fileDetail.Extension);
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
    }
}
