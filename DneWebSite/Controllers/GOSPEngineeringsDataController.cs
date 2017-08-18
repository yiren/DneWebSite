using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DneWebSite.Models.DneGOSP;
using DneWebSite.Models.bulletin;
using System.Collections;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace DneWebSite.Controllers
{
    [Route("api/gosp")]
    public class GOSPEngineeringsDataController : ApiController
    {
        private BulletinDbContext db = new BulletinDbContext();

        private Dictionary<string, string> GetDisplayGOSPScoreNameDictionary()
        {
            var valuePair = new Dictionary<string, string>();
            Type scoreType = typeof(GOSPScore);
            foreach (var property in scoreType.GetProperties())
            {
                foreach (var attr in property.GetCustomAttributes())
                {
                    if(attr is DisplayAttribute)
                    {
                        DisplayAttribute d = (DisplayAttribute)attr;
                        valuePair.Add(property.Name, d.Name);
                    }
                }
            }
            return valuePair;
        }

        private List<string> GetScoreProperties()
        {
            var properties = new List<string>();
            Type scoreType = typeof(GOSPScore);
            foreach (var property in scoreType.GetProperties())
            {
                properties.Add(property.Name);
            }
            return properties;
        }
        // GET: api/GOSPEngineeringsData
        public Object GetGOSPEngineerings()
        {
            var data = db.GOSPEngineerings.AsNoTracking().Include(g => g.GOSPScores).OrderByDescending(p => p.CreateDate).First();
            var displayNamePair = GetDisplayGOSPScoreNameDictionary();
            var scoreProperties = GetScoreProperties();
            Type scoreType = typeof(GOSPScore);
            var gospScore = data.GOSPScores;
            foreach (var property in scoreType.GetProperties())
            {
                foreach (var attr in property.GetCustomAttributes())
                {
                    if (attr is DisplayAttribute)
                    {
                        DisplayAttribute d = (DisplayAttribute)attr;
                        var dcrReviewScore2 = gospScore.Select(r =>r.DcrReviewScore);
                        var dcrReviewScoreObject2 = new
                        {
                            name = displayNamePair.First(v => v.Key == "DcrReviewScore").Value,
                            values = dcrReviewScore2
                        };
                    }
                }
            }
            var allScores = new List<Object>();
            var dcrReviewScore = gospScore.Select(r => r.DcrReviewScore);
            var dcrReviewScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "DcrReviewScore").Value,
                values = dcrReviewScore
            };
            allScores.Add(dcrReviewScoreObject);
            var dcrDefectScore = gospScore.Select(r => r.DcrReviewScore);
            var dcrDefectScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "DcrDefectScore").Value,
                values = dcrDefectScore
            };
            allScores.Add(dcrDefectScoreObject);
            var dcrCloseScore = gospScore.Select(r => r.DcrReviewScore);
            var dcrCloseScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "DcrCloseScore").Value,
                values = dcrCloseScore
            };
            allScores.Add(dcrCloseScoreObject);
            var evaPerformScore = gospScore.Select(r => r.EvaPerformanceScore);
            var evaPerformScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "EvaPerformanceScore").Value,
                values = evaPerformScore
            };
            allScores.Add(evaPerformScoreObject);
            var fcrScore = gospScore.Select(r => r.FcrScore);
            var fcrScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "FcrScore").Value,
                values = fcrScore
            };
            allScores.Add(evaPerformScoreObject);
            var backlogScore = gospScore.Select(r => r.BacklogScore);
            var backlogScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "BacklogScore").Value,
                values = backlogScore
            };
            allScores.Add(backlogScoreObject);
            var capScore = gospScore.Select(r => r.CAPScore);
            var capScoreObject = new
            {
                name = displayNamePair.First(v => v.Key == "CAPScore").Value,
                values = capScore
            };
            allScores.Add(capScoreObject);

            var dataForView = new
            {
                current=data.CurrentSeason,
                scores=allScores,
            };
            

            return dataForView;
        }

        //// GET: api/GOSPEngineeringsData/5
        //[ResponseType(typeof(GOSPEngineering))]
        //public IHttpActionResult GetGOSPEngineering(Guid id)
        //{
        //    GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Find(id);
        //    if (gOSPEngineering == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(gOSPEngineering);
        //}

        //// PUT: api/GOSPEngineeringsData/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGOSPEngineering(Guid id, GOSPEngineering gOSPEngineering)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != gOSPEngineering.EngineeringId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(gOSPEngineering).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GOSPEngineeringExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/GOSPEngineeringsData
        //[ResponseType(typeof(GOSPEngineering))]
        //public IHttpActionResult PostGOSPEngineering(GOSPEngineering gOSPEngineering)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.GOSPEngineerings.Add(gOSPEngineering);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (GOSPEngineeringExists(gOSPEngineering.EngineeringId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = gOSPEngineering.EngineeringId }, gOSPEngineering);
        //}

        //// DELETE: api/GOSPEngineeringsData/5
        //[ResponseType(typeof(GOSPEngineering))]
        //public IHttpActionResult DeleteGOSPEngineering(Guid id)
        //{
        //    GOSPEngineering gOSPEngineering = db.GOSPEngineerings.Find(id);
        //    if (gOSPEngineering == null)
        //    {
        //        return NotFound();
        //    }

        //    db.GOSPEngineerings.Remove(gOSPEngineering);
        //    db.SaveChanges();

        //    return Ok(gOSPEngineering);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GOSPEngineeringExists(Guid id)
        {
            return db.GOSPEngineerings.Count(e => e.EngineeringId == id) > 0;
        }
    }
}