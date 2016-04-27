using DneWebSite.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.ViewModel
{
    public class PostGridViewModel
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PostDate { get; set; }
        public string Category { get; set; }
        public string Section { get; set; }
        public string ModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }
        public ICollection<PostFile> PostFiles { get; set; }

    }
}