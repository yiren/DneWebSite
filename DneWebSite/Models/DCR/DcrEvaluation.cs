using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.DCR
{
    public class DcrEvaluation
    {
        [Key]
        public Guid DcrEvaluationId { get; set; }
        [DisplayName("可行性評估編號")]
        [StringLength(150)]
        public string DcrEvaluationNo { get; set; }
        [Required]
        [DisplayName("提案電廠")]
        [StringLength(15)]
        public string Plant { get; set; }

        [Required]
        [DisplayName("類別")]
        [StringLength(15)]
        public string Classification { get; set; }
       


        [Required]
        [DisplayName("要求修改內容")]

        public string Subject { get; set; }
        [Required]
        [DisplayName("來文文號")]
        [StringLength(100)]
        public string SourceNo { get; set; }
        [Required]
        [DisplayName("收文文號")]
        [StringLength(100)]
        public string DneNo { get; set; }

        [Required]
        [DisplayName("收文日期")]
        [StringLength(50)]
        public string ReceivedDate { get; set; }

        [Required]
        [DisplayName("主辦組")]
        [StringLength(20)]
        public string MainSection { get; set; }

        [Required]
        [DisplayName("承辦人")]
        [StringLength(20)]
        public string Engineer { get; set; }

        [DisplayName("會辦組別")]
        public string AssistSection { get; set; }

        [DisplayName("結案回覆日期")]
        [StringLength(50)]
        public string CloseDate { get; set; }
        [DisplayName("是否結案")]
        public bool IsClosed { get; set; }

        [DisplayName("備註")]
        public string Note { get; set; }

        [DisplayName("更新人員")]
        [StringLength(30)]
        public string LastModifiedBy { get; set; }
        [DisplayName("最後更新日期")]
        [StringLength(30)]
        public string LastModifiedDate { get; set; }

        //核發
        [DisplayName("送會辦日期")]
        public string SubmitToOperDepDate { get; set; }
        [DisplayName("審查日期")]

        public string OperDepReviewDate { get; set; }
        [DisplayName("結果")]
        public string OperDepReviewResult { get; set; }
        [Required]
        [DisplayName("是否送核發處")]
        public bool HasOperDep { get; set; }

        //核安
        [DisplayName("送會辦日期")]
        [StringLength(50)]
        public string SubmitToSafeDepDate { get; set; }
        [DisplayName("審查日期")]
        [StringLength(50)]
        public string SafeDepReviewDate { get; set; }
        [DisplayName("結果")]
        [StringLength(20)]
        public string SafeDepReviewResult { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("是否送核安處")]
        public bool HasSafeDep { get; set; }




    }
}