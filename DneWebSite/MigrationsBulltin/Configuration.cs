using System.Collections.Generic;
using DneWebSite.Models.bulletin;


namespace DneWebSite.MigrationsBulltin
{
    using Models.DCR;
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
            
            //if (!context.DcrEvaluations.Any())
            //{
            //    context.DcrEvaluations.Add(new DcrEvaluation()
            //    {
            //        DcrEvaluationId = Guid.NewGuid(),
            //        DcrEvaluationNo= "DCR-K1-XPLS",
            //        Plant = "核二廠",
            //        Classification = "R1",
            //        SourceNo = "核二改簽字106184號",
            //        DneNo = "會收106-0309",
            //        Subject = "主變壓器避雷器及附屬計數器可行性評估",
            //        ReceivedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        MainSection = "E",
            //        Engineer = "謝文龍",
            //        HasOperDep = true,
            //        SubmitToOperDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        HasSafeDep = true,
            //        SubmitToSafeDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        LastModifiedBy = "黃彥欽",
            //        LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        DcrStatus=DcrStatus.審查中
            //    });
            //}else
            //{
            //    if (context.DcrEvaluations.Count() < 3)
            //    {
            //        context.DcrEvaluations.Add(new DcrEvaluation()
            //        {
            //            DcrEvaluationId = Guid.NewGuid(),
            //            DcrEvaluationNo = "DCR-K1-HPS4",
            //            Plant = "核依廠",
            //            Classification = "R1",
            //            SourceNo = "核二改簽字106184號",
            //            DneNo = "會收106-0309",
            //            Subject = "主變壓器避雷器及附屬計數器可行性評估",
            //            ReceivedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            MainSection = "E",
            //            Engineer = "謝文龍",
            //            HasOperDep = true,
            //            SubmitToOperDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            HasSafeDep = true,
            //            SubmitToSafeDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            LastModifiedBy = "黃彥欽",
            //            LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            DcrStatus = DcrStatus.審查中,
            //            FurtherDCRReview=FurtherDCRReview.是
            //        });
            //    }
            //}


            ////var totalPosts = context.Posts;
            //if (!context.Dcrs.Any())
            //{
            //    context.Dcrs.Add(new Dcr()
            //    {
            //        DcrId = Guid.NewGuid(),
            //        Plant = "核二廠",
            //        DcrNo = "DCR-K1-4503P01",
            //        DcrEvaluationNo = "NA",
            //        Classification = "R1",
            //        Subject = "更新#1 機主變壓器避雷器及附屬計數器",
            //        SourceNo = "核二改簽字106184號",
            //        DneNo = "會收106-0309",
            //        ReceivedDate = "2017/04/19",
            //        MainSection = "E",
            //        Engineer = "謝文龍",
            //        HasOperDep = true,
            //        SubmitToOperDepDate = "2017/04/20",
            //        HasSafeDep = true,
            //        SubmitToSafeDepDate = "2017/04/20",
            //        HasAEC = false,
            //        HasSafeReg = false,
            //        LastModifiedBy="黃彥欽",
            //        LastModifiedDate= "2017/04/20"


            //    });
            //}
            
            
            ////context.Posts.RemoveRange(totalPosts);
            //context.SaveChanges();



        }
    }
}
