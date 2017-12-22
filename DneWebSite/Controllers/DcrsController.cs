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
using Npoi.Mapper;
using System.IO;
using ClosedXML;
using ClosedXML.Excel;
using Webdiyer.WebControls.Mvc;

namespace DneWebSite.Controllers
{
    //[Authorize]
    //[ClaimsAuthorize(ClaimType = "role", ClaimValue = "Dcr")]
    public class DcrsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();
        
        
        // GET: Dcrs
        [AllowAnonymous]
        public ActionResult Index(int page=1)
        {
            var dbQuery = db.Dcrs
                .AsNoTracking()
                .OrderBy(d => d.IsClosed)
                .ThenByDescending(d => d.ReceivedDate)
                .ThenByDescending(d => d.CloseDate)
                .ThenByDescending(d => d.Plant)
                .ThenByDescending(d => d.DcrNo)
                .ThenByDescending(d => d.MainSection)
                ;
                
                


            InMemoryData.DcrDataForExcelExport(dbQuery.ToList());

            var data = dbQuery.ToPagedList(page, 5);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_DcrList", data);
            }

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
        public ActionResult Create([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC,AECComment, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] Dcr dcr)
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
        public ActionResult Edit([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer,CloseDate, DcrStatus,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC,AECComment,AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] Dcr dcr)
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
        public ActionResult EditReview([Bind(Include = "DcrId,DcrNo,Plant,Classification,DcrEvaluationNo,DcrEvaluationId,Subject,SourceNo,DneNo,ReceivedDate,MainSection,Engineer, DcrStatus,CloseDate,Note,SubmitToOperDepDate,OperDepReviewDate,OperDepReviewResult,HasOperDep,SubmitToSafeDepDate,SafeDepReviewDate,SafeDepReviewResult,HasSafeDep,SubmitToSafeRegDate,SafeRegReviewDate,SafeRegReviewResult,HasSafeReg,SubmitToAECDate,SubmitDocNo,AECApprovalDate,AECApprovalDoc,HasAEC,AECComment, AssistSections, AssistSectionReviewResult, AssistSectionReviewDate, HasAssistSection")] Dcr dcr)
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
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Dcr, DcrExcelViewModel>());
           
            

            List<DcrExcelViewModel> excelFormat = 
                AutoMapper.Mapper.Map<List<DcrExcelViewModel>>(InMemoryData.DcrDataInMemoryStore);

            string path = Path.Combine(Server.MapPath("~/upload"), "dcrs.xlsx");
            //string path2 = Path.Combine(Server.MapPath("~/upload"), "dcrs2.xlsx");




            using (FileStream fs = new FileStream(path, FileMode.Create)) {
                mapper.Save(fs, excelFormat, "DCR清單");
            }

            //using (FileStream fs = new FileStream(path2, FileMode.Create))
            //{
            //    var wb = new XLWorkbook(path);
            //    var ws = wb.Worksheet(1);
            //    ws.Columns().AdjustToContents();
            //    wb.SaveAs(fs);
            //}

            return File(path, System.Net.Mime.MediaTypeNames.Application.Octet, "DCR清單"+DateTime.Now.ToString("yyyy-MM-dd")+".xlsx");
            


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
