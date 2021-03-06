﻿using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.DCR
{
    public class DcrEvaluationExcelViewModel
    {
        

        
        [Column("提案電廠")]
        public string Plant { get; set; }

        
        [Column("可行性評估編號")]
        public string DcrEvaluationNo { get; set; }
        [Column("類別")]
        public string Classification { get; set; }
        [Column("要求修改內容")]
        public string Subject { get; set; }
       
        [Column("來文文號")]
        public string SourceNo { get; set; }
    
        [Column("收文文號")]
        public string DneNo { get; set; }

    
        [Column("收文日期")]
        public string ReceivedDate { get; set; }

       
        [Column("主辦組")]
        public string MainSection { get; set; }
      
        [Column("承辦人")]
        public string Engineer { get; set; }      

       

        
        //核發
        [Column("(核發處)送會日期")]
        public string SubmitToOperDepDate { get; set; }
        [Column("(核發處)審覆日期")]

        public string OperDepReviewDate { get; set; }
        [Column("(核發處)審查結果")]
        public string OperDepReviewResult { get; set; }
           
        //核安
        [Column("(核安處)送會日期")]
        public string SubmitToSafeDepDate { get; set; }
        [Column("(核安處)審覆日期")]
        public string SafeDepReviewDate { get; set; }
        [Column("(核安處)審查結果")]
        public string SafeDepReviewResult { get; set; }
      
        
        [Column("(核技處)會辦組別")]
        public string AssistSections { get; set; }

        [Column("(核技處)審查結果")]
        public string AssistSectionReviewResult { get; set; }

        [Column("(核技處)彙總日期")]
        public string AssistSectionReviewDate { get; set; }

        [Column("回覆電廠日期")]
        public string CloseDate { get; set; }
        [Column("回覆結果")]
        public DcrStatus DcrStatus { get; set; }

        [Column("後續DCR需/不需送總處協審")]
        public FurtherDCRReview FurtherDCRReview { get; set; }

        
        [Column("備註")]
        public string Note { get; set; }
    }
}