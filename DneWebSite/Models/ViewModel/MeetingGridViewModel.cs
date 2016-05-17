using DneWebSite.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.ViewModel
{
    public class MeetingGridViewModel
    {
        public Guid MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string PostDate { get; set; }
        public string PostedBy { get; set; }
        public ICollection<MeetingFile> MeetingFiles { get; set; }

    }
}