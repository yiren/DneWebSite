using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DneWebSite.Models.bulletin;
using Newtonsoft.Json;

namespace DneWebSite.Models.common
{
    public class PostFile
    {
        [Key]
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public Guid PostId { get; set; }
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}