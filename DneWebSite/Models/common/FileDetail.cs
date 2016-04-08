using DneWebSite.Models.bulletin;
using DneWebSite.Models.dneMeeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.common
{
    class FileDetail
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public int MeetingId { get; set; }
        public virtual DneMeeting Meeting { get; set; }
    }
}
