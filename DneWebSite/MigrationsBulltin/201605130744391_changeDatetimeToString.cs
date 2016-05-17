namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatetimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meetings", "PostDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meetings", "PostDate", c => c.DateTime(nullable: false));
        }
    }
}
