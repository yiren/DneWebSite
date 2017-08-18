namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GOSPEngineerings", "CreateDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.GOSPEngineerings", "LastModifiedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.GOSPEngineerings", "LastModifiedDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.GOSPScores", "Plant", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GOSPScores", "Plant", c => c.String(nullable: false));
            AlterColumn("dbo.GOSPEngineerings", "LastModifiedDate", c => c.String());
            AlterColumn("dbo.GOSPEngineerings", "LastModifiedBy", c => c.String(nullable: false));
            DropColumn("dbo.GOSPEngineerings", "CreateDate");
        }
    }
}
