using DneWebSite.Models.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.WANO
{
    [System.Web.Mvc.Bind(Exclude = "CreatedBy, LastModifiedDate, CreatedBy, ModifiedBy")]
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }
        [DisplayName("WANO辦理事項")]
        public string ItemName { get; set; }
        [DisplayName("事項建立人員")]
        public string CreatedBy { get; set; }
        [DisplayName("最後更新人員")]
        public string ModifiedBy { get; set; }
        [DisplayName("最後修改日期")]
        public string LastModifiedDate { get; set; }

        public Boolean IsDeleted { get; set; }
        [JsonIgnore]
        public virtual ICollection<ItemFile> ItemFiles { get; set; }
    }
}
