namespace DneWebSite.MigrationsBulltin
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDcrLastModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DcrEvaluations", "LastModifiedBy", c => c.String(maxLength: 30));
            AddColumn("dbo.DcrEvaluations", "LastModifiedDate", c => c.String(maxLength: 30));
            AddColumn("dbo.Dcrs", "LastModifiedBy", c => c.String(maxLength: 30));
            AddColumn("dbo.Dcrs", "LastModifiedDate", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dcrs", "LastModifiedDate");
            DropColumn("dbo.Dcrs", "LastModifiedBy");
            DropColumn("dbo.DcrEvaluations", "LastModifiedDate");
            DropColumn("dbo.DcrEvaluations", "LastModifiedBy");
        }
    }
}
