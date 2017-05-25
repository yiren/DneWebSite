namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAssistSectionColumnDesign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dcrs", "AssistSections", c => c.String(maxLength: 100));
            AddColumn("dbo.Dcrs", "AssistSectionReviewResult", c => c.String(maxLength: 150));
            AddColumn("dbo.Dcrs", "AssistSectionReviewDate", c => c.String(maxLength: 50));
            AddColumn("dbo.Dcrs", "HasAssistSection", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "HasAssistSection");
            DropColumn("dbo.Dcrs", "AssistSectionReviewDate");
            DropColumn("dbo.Dcrs", "AssistSectionReviewResult");
            DropColumn("dbo.Dcrs", "AssistSections");
        }
    }
}
