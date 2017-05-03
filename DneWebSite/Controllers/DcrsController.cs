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
            return View(db.Dcrs
                .OrderBy(d=>d.IsClosed)
                .OrderByDescending(d=>d.ReceivedDate)
                .OrderByDescending(d => d.Plant)
                .OrderByDescending(d=>d.DcrNo)
                .OrderByDescending(d=>d.MainSection)
                .ToList());
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
        public ActionResult Create([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
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
        public ActionResult Edit([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
        {
            if (ModelState.IsValid)
            {
                if (dcr.CloseDate != string.Empty)
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
        public ActionResult EditReview([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC")] Dcr dcr)
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
