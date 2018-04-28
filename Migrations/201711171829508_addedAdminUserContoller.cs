namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdminUserContoller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        HasAdminRights = c.Boolean(nullable: false),
                        AdminTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminTypes", t => t.AdminTypeId, cascadeDelete: true)
                .Index(t => t.AdminTypeId);
            
            CreateTable(
                "dbo.AdminTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminUsers", "AdminTypeId", "dbo.AdminTypes");
            DropIndex("dbo.AdminUsers", new[] { "AdminTypeId" });
            DropTable("dbo.AdminTypes");
            DropTable("dbo.AdminUsers");
        }
    }
}
