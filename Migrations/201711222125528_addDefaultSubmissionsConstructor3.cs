namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDefaultSubmissionsConstructor3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "nameOfCause", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "organisationType", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "descriptionOfCause", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "descriptionOfCause", c => c.String());
            AlterColumn("dbo.Submissions", "organisationType", c => c.String());
            AlterColumn("dbo.Submissions", "nameOfCause", c => c.String());
        }
    }
}
