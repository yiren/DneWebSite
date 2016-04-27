namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "LastModifiedDate", c => c.String());
            AddColumn("dbo.Posts", "CreatedBy", c => c.String());
            AddColumn("dbo.Posts", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ModifiedBy");
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.Posts", "LastModifiedDate");
        }
    }
}
