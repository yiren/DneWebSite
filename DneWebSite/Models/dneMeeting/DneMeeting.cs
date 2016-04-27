using DneWebSite.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace DneWebSite.Models.dneMeeting
{

    [System.Web.Mvc.Bind(Exclude = "PostDate, PostedBy")]
    public class DneMeeting
    {
        [Key]
        public int MeetingId { get; set; }
        [DisplayName("標題")]
        public string MeetingTitle { get; set; }
        [DisplayName("發佈時間")]
        [DisplayFormat(DataFormatString ="{yyyy/MM/dd}")]
        public DateTime PostDate { get; set; }
        public string PostedBy { get; set; }
        public virtual ICollection<MeetingFile> FileDetails { get; set; }
    }
}
