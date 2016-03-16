using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.fullCalendar
{
    class Event
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Location { get; set; }
        public string Attendee { get; set; }
    }
}
