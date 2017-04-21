using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.DCR
{
    public class Dcr
    {
        public Guid DcrId { get; set; }
        public string DcrNo { get; set; }

        public string Classification { get; set; }

        public string EvaluationNo { get; set; }

        public Guid? EvaluationId { get; set; }

        public string Subject { get; set; }

        public string DocIncomeNo { get; set; }

        public string DocReceivedNo { get; set; }

        public DateTime DocReceivedDate { get; set; }

        public string MainSection { get; set; }
        
        public string AssistSection { get; set; }

        public DateTime CloseDate { get; set; }

        public string Note { get; set; }

        //核發
        public DateTime SubmitToOperDepDate { get; set; }

        public DateTime OperDepReviewDate { get; set; }

        public string OperDepReviewResult { get; set; }

        public bool IsOperDep { get; set; }

        //核安
        public DateTime SubmitToSafeDepDate { get; set; }

        public DateTime SafeDepReviewDate { get; set; }

        public string SafeDepReviewResult { get; set; }

        public bool IsSafeDep { get; set; }

        //核安會
        public DateTime SubmitToSafeRegDate { get; set; }

        public DateTime SafeRegReviewDate { get; set; }

        public string SafeRegReviewResult { get; set; }

        public bool IsSafeReg { get; set; }

        //AEC
        public DateTime SubmitToAECDate { get; set; }

        public string SubmitDocNo { get; set; }

        public DateTime AECApprovalDate { get; set; }

        public string AECApprovalDoc { get; set; }

        public bool IsAEC { get; set; }


    }
}