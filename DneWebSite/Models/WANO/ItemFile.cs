using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DneWebSite.Models.bulletin;
using Newtonsoft.Json;
using DneWebSite.Models.WANO;

namespace DneWebSite.Models.common
{
    public class ItemFile
    {
        [Key]
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public Guid ItemId { get; set; }
        [JsonIgnore]
        public virtual Item Item { get; set; }
    }
}