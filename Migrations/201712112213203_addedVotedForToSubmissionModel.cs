namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedVotedForToSubmissionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "hasUserVotedOnThis", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "hasUserVotedOnThis");
        }
    }
}
