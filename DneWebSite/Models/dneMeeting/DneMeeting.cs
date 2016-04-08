using DneWebSite.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.dneMeeting
{
    class DneMeeting
    {
        public int MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string PostDate { get; set; }

        public virtual ICollection<FileDetail> FileDetails { get; set; }
    }
}
