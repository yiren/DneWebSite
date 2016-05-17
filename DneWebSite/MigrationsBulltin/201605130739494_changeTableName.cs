namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DneMeetings", newName: "Meetings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Meetings", newName: "DneMeetings");
        }
    }
}
