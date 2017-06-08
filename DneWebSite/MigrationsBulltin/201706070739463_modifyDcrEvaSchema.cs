namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDcrEvaSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DcrEvaluations", "AssistSections", c => c.String(maxLength: 100));
            AddColumn("dbo.DcrEvaluations", "AssistSectionReviewResult", c => c.String(maxLength: 150));
            AddColumn("dbo.DcrEvaluations", "AssistSectionReviewDate", c => c.String(maxLength: 50));
            AddColumn("dbo.DcrEvaluations", "HasAssistSection", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DcrEvaluations", "HasAssistSection");
            DropColumn("dbo.DcrEvaluations", "AssistSectionReviewDate");
            DropColumn("dbo.DcrEvaluations", "AssistSectionReviewResult");
            DropColumn("dbo.DcrEvaluations", "AssistSections");
        }
    }
}
