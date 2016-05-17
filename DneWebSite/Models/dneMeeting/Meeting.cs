using DneWebSite.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace DneWebSite.Models.dneMeeting
{

    [System.Web.Mvc.Bind(Exclude = "PostDate, PostedBy")]
    public class Meeting
    {
        [Key]
        public Guid MeetingId { get; set; }
        [DisplayName("標題")]
        public string MeetingTitle { get; set; }
        [DisplayName("發佈時間")]
        public string PostDate { get; set; }
        [DisplayName("張貼人")]
        public string PostedBy { get; set; }

        public string LastModifiedBy { get; set; }

        public string LastModifiedDate { get; set; }

        public Boolean? IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<MeetingFile> MeetingFiles { get; set; }
    }
}
