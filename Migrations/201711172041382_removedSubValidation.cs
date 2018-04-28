namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSubValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "submittedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "submittedBy", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
