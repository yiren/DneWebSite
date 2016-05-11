using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.bulletin;
using DneWebSite.Models.common;
using DneWebSite.Models.dneMeeting;

namespace ConfirmEmail.Controllers
{
    [Authorize]
    public class DneMeetingController : Controller
    {
        private BulletinDbContext _db;

        public DneMeetingController()
        {
            _db=new BulletinDbContext();
        }

        // GET: DneMeeting
        public ActionResult Index()
        {

            return View(_db.DneMeetings.OrderByDescending(m=>m.PostDate).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DneMeeting entry)
        {

            if (ModelState.IsValid)
            {
                List<MeetingFile> fileDetails=new List<MeetingFile>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        MeetingFile fileDetail = new MeetingFile()
                        {
                            FileName=fileName,
                            Extension = Path.GetExtension(fileName),
                            FileId=Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);                        
                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"),
                            fileDetail.FileName + fileDetail.Extension);
                        file.SaveAs(path);
                    }   
                }
                entry.PostDate = DateTime.Now;
                entry.FileDetails = fileDetails;
                _db.DneMeetings.Add(entry);
                _db.SaveChanges();
               return RedirectToAction("Index");
                
            }
            return View(entry);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DneMeeting entry = _db.DneMeetings.Include("FileDetails").SingleOrDefault(x => x.MeetingId == id);
            if (entry == null)
            {
                return HttpNotFound();
            }


            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingId, MeetingTitle")]DneMeeting entry)
        {

            var record = _db.DneMeetings.Find(entry.MeetingId);
            if (record == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                record.MeetingTitle = entry.MeetingTitle;
                
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
                            MeetingId = entry.MeetingId
                        };
                        
                        var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"),
                            fileDetail.FileName + fileDetail.Extension);
                        file.SaveAs(path);
                        _db.Entry(fileDetail).State = EntityState.Added;
                    }
                    
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(entry);
        }

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
                MeetingFile fileDetail = _db.FileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                _db.FileDetails.Remove(fileDetail);
                _db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/upload/bulltin/dnemeeting"), fileDetail.FileName + fileDetail.Extension);
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