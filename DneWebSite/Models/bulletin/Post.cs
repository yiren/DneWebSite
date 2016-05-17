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
