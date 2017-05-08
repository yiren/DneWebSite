using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.DCR;
using DneWebSite.Models.bulletin;
using DneWebSite.Helper;
using System.Data.Entity.Infrastructure;



namespace DneWebSite.Controllers
{
    [Authorize]
    //[ClaimsAuthorize(ClaimType = "role", ClaimValue = "Dcr")]
    public class DcrsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();

        // GET: Dcrs
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = db.Dcrs
                .OrderBy(d => d.IsClosed)
                .ThenByDescending(d => d.ReceivedDate)
                .ThenByDescending(d => d.Plant)
                .ThenByDescending(d => d.DcrNo)
                .ThenByDescending(d => d.MainSection)

                .ToList();

            return View(data);
        }

        // GET: Dcrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dcrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
        {
            if (ModelState.IsValid)
            {
                dcr.DcrId = Guid.NewGuid();
                dcr.LastModifiedBy = User.Identity.Name;
                dcr.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.Dcrs.Add(dcr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dcr);
        }

        // GET: Dcrs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dcr dcr = db.Dcrs.Find(id);
            if (dcr == null)
            {
                return HttpNotFound();
            }
            
            return View(dcr);
        }

        // POST: Dcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate, DcrStatus,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
        {
            if (ModelState.IsValid)
            {
                if (dcr.DcrStatus>0)
                {
                    dcr.IsClosed = true;
                }
                dcr.LastModifiedBy = User.Identity.Name;
                dcr.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.Entry(dcr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dcr);
        }

        public ActionResult EditReview(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dcr dcr = db.Dcrs.Find(id);
            if (dcr == null)
            {
                return HttpNotFound();
            }
            return View(dcr);
        }

        // POST: Dcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
        {
            if (ModelState.IsValid)
            {
                dcr.LastModifiedBy = User.Identity.Name;
                dcr.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.Entry(dcr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dcr);
        }

        // GET: Dcrs/Delete/5
        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dcr dcr = db.Dcrs.Find(id);
            if (dcr == null)
            {
                return HttpNotFound();
            }
            return View(dcr);
        }

        // POST: Dcrs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Dcr dcr = db.Dcrs.Find(id);
            db.Dcrs.Remove(dcr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public FileResult DownloadDcrList()
        {
            var mapper = new Mapper();
            var data = db.Dcrs.ToList();
            string path = Path.Combine(Server.MapPath("~/upload"), "dcrs.xlsx");
            //var wb = new XLWorkbook();
            //var ws = wb.Worksheets.Add("Test");


            //ws.Cell(1, 1).Value = data.AsEnumerable();
            //ws.Columns().AdjustToContents();

            //using (FileStream fs = new FileStream(path, FileMode.Create))
            //{
            //    wb.SaveAs(fs);
            //    return File(fs, System.Net.Mime.MediaTypeNames.Application.Octet);
            //}


            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                mapper.Save(fs, data, "DCR清單");
                return File(fs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DCR清單.xlsx");
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
