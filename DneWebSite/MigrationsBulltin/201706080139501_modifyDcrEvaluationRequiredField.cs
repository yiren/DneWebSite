namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDcrEvaluationRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DcrEvaluations", "DcrEvaluationNo", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DcrEvaluations", "DcrEvaluationNo", c => c.String(maxLength: 150));
        }
    }
}
