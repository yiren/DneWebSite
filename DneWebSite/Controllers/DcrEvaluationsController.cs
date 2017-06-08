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
using Webdiyer.WebControls.Mvc;

namespace DneWebSite.Controllers
{
    public class DcrEvaluationsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();

        // GET: DcrEvaluations
        public ActionResult Index(int page=1)
        {
            var dbQuery = db.DcrEvaluations
                .OrderBy(d => d.IsClosed)
                .ThenByDescending(d => d.ReceivedDate)
                .ThenByDescending(d => d.Plant)
                .ThenByDescending(d => d.DcrEvaluationNo)
                .ThenByDescending(d => d.MainSection)
                .ToPagedList(page, 5);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_DcrEvaluationList", dbQuery);
            }

            return View(dbQuery);
        }

        // GET: DcrEvaluations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DcrEvaluation dcrEvaluation = db.DcrEvaluations.Find(id);
            if (dcrEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(dcrEvaluation);
        }

        // GET: DcrEvaluations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DcrEvaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DcrEvaluationId,DcrEvaluationNo,Plant,Classification,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,IsClosed,Note,LastModifiedBy,LastModifiedDate,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] DcrEvaluation dcrEvaluation)
        {
            if (ModelState.IsValid)
            {
                dcrEvaluation.DcrEvaluationId = Guid.NewGuid();
                db.DcrEvaluations.Add(dcrEvaluation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dcrEvaluation);
        }

        // GET: DcrEvaluations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DcrEvaluation dcrEvaluation = db.DcrEvaluations.Find(id);
            if (dcrEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(dcrEvaluation);
        }

        // POST: DcrEvaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DcrEvaluationId,DcrEvaluationNo,Plant,Classification,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,IsClosed,Note,LastModifiedBy,LastModifiedDate,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] DcrEvaluation dcrEvaluation)
        {
            if (ModelState.IsValid)
            {
                dcrEvaluation.LastModifiedBy = User.Identity.Name;
                dcrEvaluation.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.Entry(dcrEvaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dcrEvaluation);
        }
        public ActionResult EditReview(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DcrEvaluation dcrEva = db.DcrEvaluations.Find(id);
            if (dcrEva == null)
            {
                return HttpNotFound();
            }
            return View(dcrEva);
        }

        // POST: Dcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC,AECComment, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] DcrEvaluation dcrEva)
        {
            if (ModelState.IsValid)
            {
                dcrEva.LastModifiedBy = User.Identity.Name;
                dcrEva.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
                db.Entry(dcrEva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dcrEva);
        }
        // GET: DcrEvaluations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DcrEvaluation dcrEvaluation = db.DcrEvaluations.Find(id);
            if (dcrEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(dcrEvaluation);
        }

        // POST: DcrEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DcrEvaluation dcrEvaluation = db.DcrEvaluations.Find(id);
            db.DcrEvaluations.Remove(dcrEvaluation);
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
