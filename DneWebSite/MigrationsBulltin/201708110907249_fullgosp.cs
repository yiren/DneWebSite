namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullgosp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GOSPEngineerings",
                c => new
                    {
                        EngineeringId = c.Guid(nullable: false),
                        CurrentSeason = c.String(maxLength: 100),
                        LastModifiedBy = c.String(nullable: false),
                        LastModifiedDate = c.String(),
                    })
                .PrimaryKey(t => t.EngineeringId);
            
            CreateTable(
                "dbo.GOSPScores",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        Plant = c.String(nullable: false),
                        EngineeringId = c.Guid(),
                        DcrReviewScore = c.Single(),
                        DcrDefectScore = c.Single(),
                        DcrCloseScore = c.Single(),
                        EvaPerformanceScore = c.Single(),
                        FcrScore = c.Single(),
                        BacklogScore = c.Single(),
                        CAPScore = c.Single(),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.GOSPEngineerings", t => t.EngineeringId)
                .Index(t => t.EngineeringId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GOSPScores", "EngineeringId", "dbo.GOSPEngineerings");
            DropIndex("dbo.GOSPScores", new[] { "EngineeringId" });
            DropTable("dbo.GOSPScores");
            DropTable("dbo.GOSPEngineerings");
        }
    }
}
