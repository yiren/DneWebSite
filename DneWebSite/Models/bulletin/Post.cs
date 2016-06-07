using DneWebSite.Models.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DneWebSite.Models.bulletin
{
    [System.Web.Mvc.Bind(Exclude = "PostDate, LastModifiedDate, CreatedBy, ModifiedBy")]
    
    public class Post
    {
        public Guid PostId { get; set; }
        [DisplayName("公佈時間")]
        public string PostDate { get; set; }
        [DisplayName("標題")]
        [Required]
        public string Title { get; set; }
        [DisplayName("內容")]
        [Required]
        public string Content { get; set; }
        [DisplayName("最後修改日期")]
        public string LastModifiedDate { get; set; }
        [DisplayName("建立者")]
        public string CreatedBy { get; set; }
        [DisplayName("修改者")]
        public string ModifiedBy { get; set; }
        [Required]
        [DisplayName("張貼部門")]
        public Section Section { get; set; }
        [Required]
        [DisplayName("類別")]
        public Category Category { get; set; }

        public Boolean? IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostFile> PostFiles{ get; set; }
    }

    public enum Section
    {
        策劃組 = 0,
        PE_I = 1,
        PE_II = 2,
        核析組 = 3,
        土木組 = 4,
        廠佈組 = 5,
        機械組 = 6,
        儀控組 = 7,
        電氣組 = 8,
        人資服務=9,
        政風=10,
    }

    public enum Category
    {
        普通公告 = 0,
        進度追蹤 = 1,
        
        資訊服務 = 2,
        業務公告 = 3,
        行政作業 = 4,
        政風宣導 = 5,
        人事管理 = 6,
        訓練研討 = 7,
        其他事項 = 8
    }
}
