namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DneMeetings",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                        MeetingTitle = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        PostedBy = c.String(),
                    })
                .PrimaryKey(t => t.MeetingId);
            
            CreateTable(
                "dbo.MeetingFiles",
                c => new
                    {
                        FileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        MeetingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.DneMeetings", t => t.MeetingId, cascadeDelete: true)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "dbo.PostFiles",
                c => new
                    {
                        FileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        PostId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        PostDate = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        Section = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostFiles", "PostId", "dbo.Posts");
            DropForeignKey("dbo.MeetingFiles", "MeetingId", "dbo.DneMeetings");
            DropIndex("dbo.PostFiles", new[] { "PostId" });
            DropIndex("dbo.MeetingFiles", new[] { "MeetingId" });
            DropTable("dbo.Posts");
            DropTable("dbo.PostFiles");
            DropTable("dbo.MeetingFiles");
            DropTable("dbo.DneMeetings");
        }
    }
}
