using DneWebSite.Models.common;
using DneWebSite.Models.dneMeeting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.bulletin
{
    class BulletinDbContext:DbContext
    {
        public BulletinDbContext()
            :base("BulltinDb")
        {

        }

        
        
        public DbSet<DneMeeting> DneMeetings { get; set; }
        public DbSet<MeetingFile> FileDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
    }
}
