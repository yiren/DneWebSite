using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.DneGOSP
{
    [System.Web.Mvc.Bind(Exclude = "LastModifiedBy, LastModifiedDate")]
    public class GOSPEngineering
    {
        [Key]
        
        public Guid EngineeringId { get; set; }

        [Display(Name ="本次評分季度")]
        [StringLength(100)]
        public string CurrentSeason { get; set; }

        [StringLength(50)]
        public string CreateDate { get; set; }

        [Required]
        [Display(Name ="更新人員")]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }
        [Display(Name = "最後一次更新日期")]
        [StringLength(50)]
        public string LastModifiedDate { get; set; }
        public IList<GOSPScore> GOSPScores { get; set; }

    }
    
    public class GOSPScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreId { get; set; }

        [Required]
        [Display(Name = "電廠")]
        [StringLength(50)]
        public string Plant { get; set; }

        public Guid? EngineeringId { get; set; }
        [Display(Name = "統計每季應完成及實際SORC審查通過DCR細部設計之數量")]
        public float? DcrReviewScore { get; set; }

        [Display(Name = "每季設計案審查過程中發現之缺失之數量")]
        public float? DcrDefectScore { get; set; }

        [Display(Name = "每季自施工抄件送主辦組至全案送DCC結案為止")]
        public float? DcrCloseScore { get; set; }

        [Display(Name = "每半年完成功能評估作業績效")]
        public float? EvaPerformanceScore { get; set; }

        [Display(Name = "統計每季開立FCR數量")]
        public float? FcrScore { get; set; }

        [Display(Name = "檢討每季改善案件累積數量（backlog）")]
        public float? BacklogScore { get; set; }

        [Display(Name = "統計每季設計修改相關之CAP數量")]
        public float? CAPScore { get; set; }
    }
}