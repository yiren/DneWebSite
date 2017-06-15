namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFurtherDcrReviewCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DcrEvaluations", "FurtherDCRReview", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DcrEvaluations", "FurtherDCRReview");
        }
    }
}
