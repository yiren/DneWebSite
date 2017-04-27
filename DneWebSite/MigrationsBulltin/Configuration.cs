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


            //var totalPosts = context.Posts;
            if (!context.Dcrs.Any())
            {
                context.Dcrs.Add(new Dcr()
                {
                    DcrId = Guid.NewGuid(),
                    Plant = "�֤G�t",
                    DcrNo = "DCR-K1-4503P01",
                    DcrEvaluationNo = "NA",
                    Classification = "R1",
                    Subject = "��s#1 ���D�������׹p���Ϊ��ݭp�ƾ�",
                    SourceNo = "�֤G��ñ�r106184��",
                    DneNo = "�|��106-0309",
                    ReceivedDate = "2017/04/19",
                    MainSection = "E",
                    Engineer = "�¤��s",
                    HasOperDep = true,
                    SubmitToOperDepDate = "2017/04/20",
                    HasSafeDep = true,
                    SubmitToSafeDepDate = "2017/04/20",
                    HasAEC = false,
                    HasSafeReg = false,
                    LastModifiedBy="���۴�",
                    LastModifiedDate= "2017/04/20",
                    DcrStatus=DcrStatus.Closed,
                    CloseDate="2017/04/27"


                });
            }
            
            
            //context.Posts.RemoveRange(totalPosts);
            context.SaveChanges();



        }
    }
}
