namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsDeleted1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "IsDeleted");
        }
    }
}
