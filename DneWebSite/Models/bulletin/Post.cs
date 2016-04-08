using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.bulletin
{
    class Post
    {
        public Guid PostId { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string Department { get; set; }
        public string Category { get; set; }

        public virtual ICollection<FileDetail> FileDetails{ get; set; }
    }
}
