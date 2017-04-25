namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrEva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DcrEvaluations",
                c => new
                    {
                        DcrEvaluationId = c.Guid(nullable: false),
                        DcrEvaluationNo = c.String(maxLength: 150),
                        Plant = c.String(nullable: false, maxLength: 15),
                        Classification = c.String(nullable: false, maxLength: 15),
                        Subject = c.String(nullable: false),
                        SourceNo = c.String(nullable: false, maxLength: 100),
                        DneNo = c.String(nullable: false, maxLength: 100),
                        ReceivedDate = c.String(nullable: false, maxLength: 50),
                        MainSection = c.String(nullable: false, maxLength: 20),
                        Engineer = c.String(nullable: false, maxLength: 20),
                        AssistSection = c.String(),
                        CloseDate = c.String(maxLength: 50),
                        IsClosed = c.Boolean(nullable: false),
                        Note = c.String(),
                        SubmitToOperDepDate = c.String(),
                        OperDepReviewDate = c.String(),
                        OperDepReviewResult = c.String(),
                        HasOperDep = c.Boolean(nullable: false),
                        SubmitToSafeDepDate = c.String(maxLength: 50),
                        SafeDepReviewDate = c.String(maxLength: 50),
                        SafeDepReviewResult = c.String(maxLength: 20),
                        HasSafeDep = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DcrEvaluationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DcrEvaluations");
        }
    }
}
