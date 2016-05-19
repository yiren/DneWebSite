namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItemFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemFiles",
                c => new
                    {
                        FileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        ItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemFiles", "ItemId", "dbo.Items");
            DropIndex("dbo.ItemFiles", new[] { "ItemId" });
            DropTable("dbo.ItemFiles");
        }
    }
}
