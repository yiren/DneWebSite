using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DneWebSite.Models.DneGOSP;
using DneWebSite.Models.bulletin;

namespace DneWebSite.Controllers
{
    public class GOSPEngineeringsController : Controller
    {
        private BulletinDbContext db = new BulletinDbContext();

        // GET: GOSPEngineerings
        public ActionResult Index()
        {
            return View(db.GOSPEngineerings.Include(g=>g.GOSPScores).OrderByDescending(p => p.CurrentSeason).ThenByDescending(p => p.LastModifiedDate).ToList());
        }

        public ActionResult Single()
        {
            return View(db.GOSPEngineerings.OrderByDescending(p => p.CurrentSeason).ThenByDescending(p => p.LastModifiedDate).First());
        }

        // GET: GOSPEngineerings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Find(id);
            if (gOSPEngineering == null)
            {
                return HttpNotFound();
            }
            return View(gOSPEngineering);
        }

        // GET: GOSPEngineerings/Create
        public ActionResult Create()
        {
            GOSPEngineering gosp = db.GOSPEngineerings.Include(g=>g.GOSPScores).First();
            return View(gosp);
        }

        // POST: GOSPEngineerings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GOSPEngineering gosp)
        {           
            gosp.EngineeringId = Guid.NewGuid();
            gosp.LastModifiedBy = "test";
            gosp.CreateDate= DateTime.Now.ToString("yyyy/MM/dd");
            gosp.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
            foreach (var item in gosp.GOSPScores)
            {
                item.EngineeringId = gosp.EngineeringId;
            }
            db.GOSPEngineerings.Add(gosp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: GOSPEngineerings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Include(p=>p.GOSPScores).Where(p=>p.EngineeringId==id).SingleOrDefault();
            if (gOSPEngineering == null)
            {
                return HttpNotFound();
            }

            return View(gOSPEngineering);
        }

        // POST: GOSPEngineerings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GOSPEngineering gOSPEngineering)
        {
            gOSPEngineering.LastModifiedBy = "test2";
            gOSPEngineering.LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
            db.Entry(gOSPEngineering).State = EntityState.Modified;
            foreach (var score in gOSPEngineering.GOSPScores)
            {
                db.Entry(score).State = EntityState.Modified;
            }
                //GOSPEngineering g2 = gOSPEngineering;
                //g2.EngineeringId = Guid.NewGuid();
                //db.GOSPEngineerings.Add(g2);
                
                if(db.SaveChanges()>0)
                return RedirectToAction("Index");
           
            return View(gOSPEngineering);
        }

        // GET: GOSPEngineerings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Find(id);
            if (gOSPEngineering == null)
            {
                return HttpNotFound();
            }
            return View(gOSPEngineering);
        }

        // POST: GOSPEngineerings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Include(g=>g.GOSPScores).FirstOrDefault(g=>g.EngineeringId==id);
            db.GOSPEngineerings.Remove(gOSPEngineering);
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
