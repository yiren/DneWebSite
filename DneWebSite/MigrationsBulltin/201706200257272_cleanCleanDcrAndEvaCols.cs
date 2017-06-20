namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanCleanDcrAndEvaCols : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DcrEvaluations", "AssistSection");
            
            DropColumn("dbo.Dcrs", "AssistSection");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dcrs", "AssistSection", c => c.String());
           
            AddColumn("dbo.DcrEvaluations", "AssistSection", c => c.String());
        }
    }
}
