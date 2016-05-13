using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DneWebSite.Models.bulletin;
using DneWebSite.Models.ViewModel;

namespace DneWebSite.Models.BulltinRespository
{
    public class PostsRespository
    {
        private BulletinDbContext db=new BulletinDbContext();

  
        //For WebAPI Use Only
        public IQueryable GetPosts()
        {
            var data = from p in db.Posts
                       orderby p.PostDate descending 
                select new PostGridViewModel()
                {
                    PostId = p.PostId,
                    Section = p.Section.ToString(),
                    Category = p.Category.ToString(),
                    Content = p.Content,
                    PostDate = p.PostDate,
                    Title = p.Title,
                    PostFiles=p.PostFiles,
                    ModifiedBy=p.ModifiedBy,
                    LastModifiedDate=p.LastModifiedDate
                };

            return data;
        }
    }
}