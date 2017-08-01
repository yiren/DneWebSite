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
            //        Plant = "�֤G�t",
            //        Classification = "R1",
            //        SourceNo = "�֤G��ñ�r106184��",
            //        DneNo = "�|��106-0309",
            //        Subject = "�D�������׹p���Ϊ��ݭp�ƾ��i��ʵ���",
            //        ReceivedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        MainSection = "E",
            //        Engineer = "�¤��s",
            //        HasOperDep = true,
            //        SubmitToOperDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        HasSafeDep = true,
            //        SubmitToSafeDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        LastModifiedBy = "���۴�",
            //        LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //        DcrStatus=DcrStatus.�f�d��
            //    });
            //}else
            //{
            //    if (context.DcrEvaluations.Count() < 3)
            //    {
            //        context.DcrEvaluations.Add(new DcrEvaluation()
            //        {
            //            DcrEvaluationId = Guid.NewGuid(),
            //            DcrEvaluationNo = "DCR-K1-HPS4",
            //            Plant = "�̼֨t",
            //            Classification = "R1",
            //            SourceNo = "�֤G��ñ�r106184��",
            //            DneNo = "�|��106-0309",
            //            Subject = "�D�������׹p���Ϊ��ݭp�ƾ��i��ʵ���",
            //            ReceivedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            MainSection = "E",
            //            Engineer = "�¤��s",
            //            HasOperDep = true,
            //            SubmitToOperDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            HasSafeDep = true,
            //            SubmitToSafeDepDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            LastModifiedBy = "���۴�",
            //            LastModifiedDate = DateTime.Now.ToString("yyyy/MM/dd"),
            //            DcrStatus = DcrStatus.�f�d��,
            //            FurtherDCRReview=FurtherDCRReview.�O
            //        });
            //    }
            //}


            ////var totalPosts = context.Posts;
            //if (!context.Dcrs.Any())
            //{
            //    context.Dcrs.Add(new Dcr()
            //    {
            //        DcrId = Guid.NewGuid(),
            //        Plant = "�֤G�t",
            //        DcrNo = "DCR-K1-4503P01",
            //        DcrEvaluationNo = "NA",
            //        Classification = "R1",
            //        Subject = "��s#1 ���D�������׹p���Ϊ��ݭp�ƾ�",
            //        SourceNo = "�֤G��ñ�r106184��",
            //        DneNo = "�|��106-0309",
            //        ReceivedDate = "2017/04/19",
            //        MainSection = "E",
            //        Engineer = "�¤��s",
            //        HasOperDep = true,
            //        SubmitToOperDepDate = "2017/04/20",
            //        HasSafeDep = true,
            //        SubmitToSafeDepDate = "2017/04/20",
            //        HasAEC = false,
            //        HasSafeReg = false,
            //        LastModifiedBy="���۴�",
            //        LastModifiedDate= "2017/04/20"


            //    });
            //}
            
            
            ////context.Posts.RemoveRange(totalPosts);
            //context.SaveChanges();



        }
    }
}
