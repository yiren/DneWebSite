using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.FullCalendar
{
    public class FullCalendarDbContext:DbContext
    {
        public FullCalendarDbContext():base("DneFullCalendarDb")
        {
            Database.SetInitializer<FullCalendarDbContext>(new FullCalendarDbInitializer());
        }

        public DbSet<Event> Events { get; set; }
    }

    public class FullCalendarDbInitializer : CreateDatabaseIfNotExists<FullCalendarDbContext>
    {
        protected override void Seed(FullCalendarDbContext context)
        {
            new List<Event>
            {
                new Event() {Id=1, Title = "核技處、核發處聯合晨會", Start = "2016-03-17 08:15", Allday = false},
                new Event() {Id = 2, Title = "核心訓練", Start ="15:15",End = "2016-03-17 17:15", Allday = false}
            }.ForEach(e=> context.Events.Add(e));

            context.SaveChanges();
           
        }
    }
}