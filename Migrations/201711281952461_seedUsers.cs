namespace Community_Trust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'20ad8337-0a9d-428e-b4a9-8a7bd1d0dbda', N'rorywalshe1@gmail.com', 0, N'AHuWG3qqJEP6L7PKbhxyYkKu/GY1y7t139zhl2mz9pTHSw79pEE3IbkjuKyNaSaMvQ==', N'd8cc5bd9-4d25-47d2-8b1a-892f7a63694c', NULL, 0, 0, NULL, 1, 0, N'rorywalshe1@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3fe3361f-e4e2-4404-acd3-ce588355481a', N'guest@communitytrust.com', 0, N'ADwoJO9WeXN3whwxtA9ItCyAhu3NA/lsglSrE3LcNu2CTKJdp20Dv3IbQNHrcf4DiA==', N'f53c1e64-f1e0-41d6-aa16-6eadde5d6e91', NULL, 0, 0, NULL, 1, 0, N'guest@communitytrust.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f215465c-9a57-44be-b38a-a89ace84311e', N'admin@communitytrust.com', 0, N'AF62sBZHfVawCQJSGMYdwFljwr4N9lpsZMGnCjFThg8tBFLNn1OuKpBd/FKZYD6VBg==', N'7fb2274d-e7f2-40a4-91b3-c7cc40dfddf6', NULL, 0, 0, NULL, 1, 0, N'admin@communitytrust.com')
                   INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bd343954-6fa0-48d1-9603-9b6298a21e82', N'CanManageSubmissions')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Katelyn')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Rory') 
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f215465c-9a57-44be-b38a-a89ace84311e', N'bd343954-6fa0-48d1-9603-9b6298a21e82')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
