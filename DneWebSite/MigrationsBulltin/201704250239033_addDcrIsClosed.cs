namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrIsClosed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dcrs", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "IsClosed");
        }
    }
}
