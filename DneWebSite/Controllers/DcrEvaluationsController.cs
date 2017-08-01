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
using Npoi.Mapper;
using DneWebSite.Helper;
using System.IO;

namespace DneWebSite.Controllers
{
    [Authorize]
    public class DcrEvaluationsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();
        [AllowAnonymous]
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

            InMemoryData.DcrEvaluationDataForExcelExport(dbQuery);

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
        public ActionResult Create([Bind(Include = "DcrEvaluationId,DcrEvaluationNo,Plant,Classification,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,IsClosed,Note,LastModifiedBy,LastModifiedDate,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection,FurtherDCRReview")] DcrEvaluation dcrEvaluation)
        {
            if (ModelState.IsValid)
            {
                dcrEvaluation.DcrEvaluationId = Guid.NewGuid();
                dcrEvaluation.LastModifiedBy = User.Identity.Name;
                dcrEvaluation.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
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
        public ActionResult Edit([Bind(Include = "DcrEvaluationId,DcrEvaluationNo,Plant,Classification,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,AssistSection,CloseDate,IsClosed,Note,DcrStatus,LastModifiedBy,LastModifiedDate,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection,FurtherDCRReview")] DcrEvaluation dcrEvaluation)
        {
            if (ModelState.IsValid)
            {
                if (dcrEvaluation.DcrStatus > 0)
                {
                    dcrEvaluation.IsClosed = true;
                }
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
        public ActionResult EditReview([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC,AECComment, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection,FurtherDCRReview")] DcrEvaluation dcrEva)
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

        [AllowAnonymous]
        public FileResult DownloadDcrEvaluationList()
        {
            var mapper = new Mapper();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<DcrEvaluation, DcrEvaluationExcelViewModel>());



            List<DcrEvaluationExcelViewModel> excelFormat =
                AutoMapper.Mapper.Map<List<DcrEvaluationExcelViewModel>>(InMemoryData.DcrEvaluationDataInMemoryStore);

            string path = Path.Combine(Server.MapPath("~/upload"), "dcrEvaluations.xlsx");
            //string path2 = Path.Combine(Server.MapPath("~/upload"), "dcrs2.xlsx");




            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                mapper.Save(fs, excelFormat, "DCR可行性評估清單");
            }

            //using (FileStream fs = new FileStream(path2, FileMode.Create))
            //{
            //    var wb = new XLWorkbook(path);
            //    var ws = wb.Worksheet(1);
            //    ws.Columns().AdjustToContents();
            //    wb.SaveAs(fs);
            //}

            return File(path, System.Net.Mime.MediaTypeNames.Application.Octet, "DCR可行性評估清單" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx");



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
