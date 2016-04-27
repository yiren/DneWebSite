using DneWebSite.Models.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DneWebSite.Models.bulletin
{
    [System.Web.Mvc.Bind(Exclude = "PostDate, LastModifiedDate, CreatedBy, ModifiedBy")]
    
    public class Post
    {
        public Guid PostId { get; set; }
        public string PostDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Section Section { get; set; }
        
        public Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostFile> PostFiles{ get; set; }
    }

    public enum Section
    {
        策劃組 = 1,
        PE_I = 2,
        PE_II = 3,
        核析組 = 4,
        土木組 = 5,
        廠佈組 = 6,
        機械組 = 7,
        儀控組 = 8,
        電氣組 = 9,
        處長室 = 10,
    }

    public enum Category
    {
        普通公告 = 1,
        進度追蹤 = 2,
        
        資訊服務 = 3,
        業務公告 = 4,
        行政作業 = 5,
        政風宣導 = 6,
        人事管理 = 7,
        訓練研討 = 8,
        其他事項 = 9
    }
}
