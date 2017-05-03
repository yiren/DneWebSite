namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dcrs", "DcrStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "DcrStatus");
        }
    }
}
