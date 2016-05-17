using DneWebSite.Models.bulletin;
using DneWebSite.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.MeetingRespository
{
    public class MeetingRepository
    {
        private BulletinDbContext db = new BulletinDbContext();


        //For WebAPI Use Only
        public IQueryable GetMeetings()
        {
            var data = from m in db.Meetings
                       where m.IsDeleted != true
                       orderby m.PostDate descending
                       select new MeetingGridViewModel()
                       {
                           MeetingId = m.MeetingId,
                           MeetingTitle=m.MeetingTitle,
                           PostDate = m.PostDate,
                           MeetingFiles = m.MeetingFiles,
                           PostedBy = m.PostedBy
                           
                       };

            return data;
        }
    }
}