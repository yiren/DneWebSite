using DneWebSite.Models.common;
using DneWebSite.Models.dneMeeting;
using DneWebSite.Models.WANO;
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
            :base(ConnectionStrings.baseConnectionString("BulltinDb"))
        {

        }

        
        
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingFile> FileDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemFile> ItemFiles { get; set; }

        
    }
}
