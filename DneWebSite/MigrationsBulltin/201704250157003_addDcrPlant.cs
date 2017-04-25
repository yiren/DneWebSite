namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrPlant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dcrs", "Plant", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "Plant");
        }
    }
}
