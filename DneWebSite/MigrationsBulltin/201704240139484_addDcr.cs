namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dcrs",
                c => new
                    {
                        DcrId = c.Guid(nullable: false),
                        DcrNo = c.String(nullable: false, maxLength: 100),
                        Classification = c.String(nullable: false, maxLength: 15),
                        DcrEvaluationNo = c.String(maxLength: 150),
                        DcrEvaluationId = c.Guid(),
                        Subject = c.String(nullable: false),
                        SourceNo = c.String(nullable: false, maxLength: 100),
                        DneNo = c.String(nullable: false, maxLength: 100),
                        ReceivedDate = c.String(nullable: false, maxLength: 50),
                        MainSection = c.String(nullable: false, maxLength: 20),
                        Engineer = c.String(nullable: false, maxLength: 20),
                        AssistSection = c.String(),
                        CloseDate = c.String(maxLength: 50),
                        Note = c.String(),
                        SubmitToOperDepDate = c.String(),
                        OperDepReviewDate = c.String(),
                        OperDepReviewResult = c.String(),
                        HasOperDep = c.Boolean(nullable: false),
                        SubmitToSafeDepDate = c.String(maxLength: 50),
                        SafeDepReviewDate = c.String(maxLength: 50),
                        SafeDepReviewResult = c.String(maxLength: 20),
                        HasSafeDep = c.Boolean(nullable: false),
                        SubmitToSafeRegDate = c.String(maxLength: 50),
                        SafeRegReviewDate = c.String(maxLength: 50),
                        SafeRegReviewResult = c.String(maxLength: 20),
                        HasSafeReg = c.Boolean(nullable: false),
                        SubmitToAECDate = c.String(maxLength: 50),
                        SubmitDocNo = c.String(maxLength: 150),
                        AECApprovalDate = c.String(maxLength: 50),
                        AECApprovalDoc = c.String(maxLength: 150),
                        HasAEC = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DcrId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dcrs");
        }
    }
}
