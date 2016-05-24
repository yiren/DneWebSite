using System.Collections.Generic;
using DneWebSite.Models.bulletin;


namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DneWebSite.Models.bulletin.BulletinDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MigrationsBulltin";
        }

        protected override void Seed(DneWebSite.Models.bulletin.BulletinDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var totalPosts = context.Posts;
            context.Posts.RemoveRange(totalPosts);
            context.SaveChanges();


            if (context.Posts.Count() <1000)
            {
                List<Post> posts = new List<Post>();
                Random rnd = new Random();
                for (int i = 1; i < 10000; i++)
                {
                    Post post = new Post()
                    {
                        Category = (Category)rnd.Next(1, 5),
                        Section = (Section)rnd.Next(1, 5),
                        Content = "Test Data Content" + i,
                        Title = "Test Data Title" + i,
                        PostDate = (DateTime.Now - TimeSpan.FromDays((double)i)).ToString("yyyy/MM/dd"),
                        PostId = Guid.NewGuid()

                    };
                    posts.Add(post);
                }
                foreach (var post in posts)
                {
                    context.Posts.AddOrUpdate(post);
                }
                context.SaveChanges();
            }



        }
    }
}
