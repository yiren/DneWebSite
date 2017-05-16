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
        審查中,
        [Display(Name = "同意")]
        [Description("同意")]
        同意,
        [Display(Name = "有意見")]
        [Description("有意見")]
        有意見
    }
}