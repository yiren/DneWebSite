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
using DneWebSite.Models.bulletin;
using DneWebSite.Models.dneMeeting;
using DneWebSite.Models.MeetingRespository;

namespace DneWebSite.Controllers
{
    //AngularJS取得資料End Point
    public class MeetingsDataController : ApiController
    {
        private BulletinDbContext db = new BulletinDbContext();
        private MeetingRepository _db = new MeetingRepository();

        // GET: api/DneMeetingData
        public IQueryable GetMeetings()
        {
            return _db.GetMeetings();
        }

        // GET: api/DneMeetingData/5
        //[ResponseType(typeof(Meeting))]
        //public IHttpActionResult GetDneMeeting(Guid id)
        //{
        //    Meeting dneMeeting = db.Meetings.Find(id);
        //    if (dneMeeting == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dneMeeting);
        //}

        //// PUT: api/DneMeetingData/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDneMeeting(Guid id, Meeting dneMeeting)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dneMeeting.MeetingId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(dneMeeting).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DneMeetingExists(id))
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

        //// POST: api/DneMeetingData
        //[ResponseType(typeof(Meeting))]
        //public IHttpActionResult PostDneMeeting(Meeting dneMeeting)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Meetings.Add(dneMeeting);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DneMeetingExists(dneMeeting.MeetingId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = dneMeeting.MeetingId }, dneMeeting);
        //}

        //// DELETE: api/DneMeetingData/5
        //[ResponseType(typeof(Meeting))]
        //public IHttpActionResult DeleteDneMeeting(Guid id)
        //{
        //    Meeting dneMeeting = db.Meetings.Find(id);
        //    if (dneMeeting == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Meetings.Remove(dneMeeting);
        //    db.SaveChanges();

        //    return Ok(dneMeeting);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DneMeetingExists(Guid id)
        {
            return db.Meetings.Count(e => e.MeetingId == id) > 0;
        }
    }
}