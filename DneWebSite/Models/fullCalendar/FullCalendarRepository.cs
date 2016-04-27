using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DneWebSite.Models.FullCalendar
{
    public class FullCalendarRepository : IFullCalendarRepository
    {
        private FullCalendarDbContext context =new FullCalendarDbContext();
        public IEnumerable<Event> Events
        {
            get { return context.Events; }
        }

        public async Task<Event> DeleteEventAsync(int eventId)
        {
            Event dbEntry = context.Events.Find(eventId);
            if (dbEntry != null)
            {
                context.Events.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public async Task<int> SaveEventAsync(Event e)
        {
            if (e.Id == 0)
            {
                context.Events.Add(e);
            }
            else
            {
                Event dbEntry = context.Events.Find(e.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = e.Title;
                    dbEntry.Start = e.Start;
                    dbEntry.End = e.End;
                    dbEntry.Allday = e.Allday;
                }
            }

            return await context.SaveChangesAsync();
        }
    }
}