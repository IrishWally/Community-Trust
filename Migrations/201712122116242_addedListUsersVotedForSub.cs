namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedListUsersVotedForSub : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Submission_subKey", "dbo.Submissions");
            DropIndex("dbo.AspNetUsers", new[] { "Submission_subKey" });
            DropColumn("dbo.AspNetUsers", "Submission_subKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Submission_subKey", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Submission_subKey");
            AddForeignKey("dbo.AspNetUsers", "Submission_subKey", "dbo.Submissions", "subKey");
        }
    }
}
