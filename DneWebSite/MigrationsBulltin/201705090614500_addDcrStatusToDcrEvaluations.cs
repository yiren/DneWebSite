namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrStatusToDcrEvaluations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DcrEvaluations", "DcrStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DcrEvaluations", "DcrStatus");
        }
    }
}
