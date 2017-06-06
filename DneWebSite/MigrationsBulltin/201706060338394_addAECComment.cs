namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAECComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dcrs", "AECComment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "AECComment");
        }
    }
}
