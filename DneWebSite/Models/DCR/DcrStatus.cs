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
        [Display(Name = "審查中")]
        [Description("審查中")]
        Reviewing,
        [Display(Name = "結案")]
        [Description("結案")]
        Closed,
        [Display(Name = "有意見")]
        [Description("有意見")]
        HasComment
    }
}