namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increaseReviewResultLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DcrEvaluations", "OperDepReviewResult", c => c.String(maxLength: 150));
            AlterColumn("dbo.DcrEvaluations", "SafeDepReviewResult", c => c.String(maxLength: 150));
            AlterColumn("dbo.Dcrs", "OperDepReviewResult", c => c.String(maxLength: 150));
            AlterColumn("dbo.Dcrs", "SafeDepReviewResult", c => c.String(maxLength: 150));
            AlterColumn("dbo.Dcrs", "SafeRegReviewResult", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dcrs", "SafeRegReviewResult", c => c.String(maxLength: 20));
            AlterColumn("dbo.Dcrs", "SafeDepReviewResult", c => c.String(maxLength: 20));
            AlterColumn("dbo.Dcrs", "OperDepReviewResult", c => c.String());
            AlterColumn("dbo.DcrEvaluations", "SafeDepReviewResult", c => c.String(maxLength: 20));
            AlterColumn("dbo.DcrEvaluations", "OperDepReviewResult", c => c.String());
        }
    }
}
