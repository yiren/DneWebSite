namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlLastModifiedAttr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "LastModifiedBy", c => c.String());
            AddColumn("dbo.Meetings", "LastModifiedDate", c => c.String());
            AddColumn("dbo.Meetings", "IsDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "IsDeleted");
            DropColumn("dbo.Meetings", "LastModifiedDate");
            DropColumn("dbo.Meetings", "LastModifiedBy");
        }
    }
}
