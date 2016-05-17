namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMeetingIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetingFiles", "MeetingId", "dbo.DneMeetings");
            DropIndex("dbo.MeetingFiles", new[] { "MeetingId" });
            DropPrimaryKey("dbo.DneMeetings");
            DropColumn("dbo.DneMeetings", "MeetingId");
            DropColumn("dbo.MeetingFiles", "MeetingId");
            AddColumn("dbo.DneMeetings", "MeetingId", c => c.Guid(nullable: false));
            AddColumn("dbo.MeetingFiles", "MeetingId", c => c.Guid(nullable : false));
            AddPrimaryKey("dbo.DneMeetings", "MeetingId");
            CreateIndex("dbo.MeetingFiles", "MeetingId");
            AddForeignKey("dbo.MeetingFiles", "MeetingId", "dbo.DneMeetings", "MeetingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingFiles", "MeetingId", "dbo.DneMeetings");
            DropIndex("dbo.MeetingFiles", new[] { "MeetingId" });
            DropPrimaryKey("dbo.DneMeetings");
            AlterColumn("dbo.MeetingFiles", "MeetingId", c => c.Int(nullable: false));
            AlterColumn("dbo.DneMeetings", "MeetingId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DneMeetings", "MeetingId");
            CreateIndex("dbo.MeetingFiles", "MeetingId");
            AddForeignKey("dbo.MeetingFiles", "MeetingId", "dbo.DneMeetings", "MeetingId", cascadeDelete: true);
        }
    }
}
