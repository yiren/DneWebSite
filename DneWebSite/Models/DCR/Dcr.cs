using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.DCR
{
    public enum DcrStatus
    {   
        [Display(Name ="審查中")]
        [Description("審查中")]
        Reviewing,
        [Display(Name ="結案")]
        [Description("結案")]
        Closed,
        [Display(Name = "有意見")]
        [Description("有意見")]
        HasComment
    }
    public class Dcr
    {
        [Key]
        public Guid DcrId { get; set; }
        [Required]
        [DisplayName("編號")]
        [StringLength(100)]
        public string DcrNo { get; set; }

        [Required]
        [DisplayName("提案電廠")]
        [StringLength(15)]
        public string Plant { get; set; }

        [Required]
        [DisplayName("類別")]
        [StringLength(15)]
        public string Classification { get; set; }
        [DisplayName("可行性評估編號")]
        [StringLength(150)]
        public string DcrEvaluationNo { get; set; }

        public Guid? DcrEvaluationId { get; set; }

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

        [DisplayName("審查結果")]
        public DcrStatus DcrStatus { get; set; }

        [DisplayName("回覆日期")]
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
        [DisplayName("送會日期")]
        public string SubmitToOperDepDate { get; set; }
        [DisplayName("審覆日期")]
        
        public string OperDepReviewDate { get; set; }
        [DisplayName("結果")]
        public string OperDepReviewResult { get; set; }
        [Required]
        [DisplayName("是否送核發處")]
        public bool HasOperDep { get; set; }

        //核安
        [DisplayName("送會日期")]
        [StringLength(50)]
        public string SubmitToSafeDepDate { get; set; }
        [DisplayName("審覆日期")]
        [StringLength(50)]
        public string SafeDepReviewDate { get; set; }
        [DisplayName("結果")]
        [StringLength(20)]
        public string SafeDepReviewResult { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("是否送核安處")]
        public bool HasSafeDep { get; set; }

        //核安會
        [DisplayName("送會日期")]
        [StringLength(50)]
        public string SubmitToSafeRegDate { get; set; }

        [DisplayName("審覆日期")]
        [StringLength(50)]
        public string SafeRegReviewDate { get; set; }
        [DisplayName("結果")]
        [StringLength(20)]
        public string SafeRegReviewResult { get; set; }

        [Required]
        [DisplayName("是否送核安會")]
        public bool HasSafeReg { get; set; }

        //AEC
        [DisplayName("陳報日期")]
        [StringLength(50)]
        public string SubmitToAECDate { get; set; }

        [DisplayName("陳報文號")]
        [StringLength(150)]
        public string SubmitDocNo { get; set; }

        [DisplayName("核准日期")]
        [StringLength(50)]
        public string AECApprovalDate { get; set; }
        [DisplayName("核准文號")]
        [StringLength(150)]
        public string AECApprovalDoc { get; set; }
        [Required]
        [DisplayName("是否需陳報AEC")]
        public bool HasAEC { get; set; }


    }
}