using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.FullCalendar
{
    interface IFullCalendarRepository
    {
        IEnumerable<Event> Events { get;}
        Task<int> SaveEventAsync(Event e);
        Task<Event> DeleteEventAsync(int eventId);


    }
}
