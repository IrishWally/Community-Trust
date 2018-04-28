namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminType : DbMigration
    {
        public override void Up()
        {

            Sql("Insert into AspNetRoles(Id,Name) VALUES(1,'Rory')");
            Sql("Insert into AspNetRoles(Id,Name) VALUES(2, 'Katelyn')");
        }
        
        public override void Down()
        {
        }
    }
}
