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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using DneWebSite.Helper;

namespace DneWebSite.Controllers
{
    [ClaimsAuthorize(ClaimType = "role", ClaimValue = "GOSP")]
    public class GOSPEngineeringsController : Controller
    {
        public GOSPEngineeringsController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        private BulletinDbContext db = new BulletinDbContext();
        private ApplicationUserManager _userManager;
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
        // GET: GOSPEngineerings
        public ActionResult Index()
        {
            return View(db.GOSPEngineerings.AsNoTracking().Include(g => g.GOSPScores).OrderByDescending(p => p.CreateDate).ToList());
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
            var user = UserManager.FindByName(User.Identity.Name);
            gosp.LastModifiedBy = user.FullName;
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
            var user = UserManager.FindByName(User.Identity.Name);
            gOSPEngineering.LastModifiedBy = user.FullName;
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
