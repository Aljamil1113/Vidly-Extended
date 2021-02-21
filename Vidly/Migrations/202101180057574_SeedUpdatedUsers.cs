namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUpdatedUsers : DbMigration
    {
        public override void Up()
        {
            //Sql(@"
            //      INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [MobileNumber]) VALUES (N'25ec0e67-4cf6-4276-872d-90c3ff5e2636', N'guest@vidly.com', 0, N'ABG6KQCacdzdOUSP5AiEsowfanCtp/qjKifLuk+vbZcuJQINlcUc3VPCXgPjNsy8WQ==', N'a500a5c3-4463-4cc7-bc75-94726be022a0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com', N'', N'')
            //      INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [MobileNumber]) VALUES (N'6234db39-c289-4d29-a220-d80ac98661dc', N'admin@vidly.com', 0, N'AD/vXGlh0ocfF/2GB/6vo7o2AtNXmcY5PBLPyz+lxYgSH9DhiBKetXoQrEZZ+XFF7Q==', N'bd8ea863-b103-4d62-b823-dc1e8829a6c1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'', N'')
            //      INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [MobileNumber]) VALUES (N'a5d08b64-356f-4961-ad7c-de4f28fd1e25', N'superadmin@vidly.com', 0, N'AN9wFmUCWYQ8ouG+FjeCF2DOkUrPcmAYViHHTs/4wuwQkAnk761HV/DB28QvvgzsVQ==', N'5d155c5d-624d-49ac-b368-3567abe3a516', NULL, 0, 0, NULL, 1, 0, N'superadmin@vidly.com', N'S0909090909', N'09123456789')


            //      INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5449390f-ce5b-4c66-b76f-317776569f25', N'CanManageMovies')
            //      INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'ec25657d-17bc-4168-a54d-36335bc41cb4', N'Super Admin')
                    
            //      INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6234db39-c289-4d29-a220-d80ac98661dc', N'5449390f-ce5b-4c66-b76f-317776569f25')
            //      INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a5d08b64-356f-4961-ad7c-de4f28fd1e25', N'ec25657d-17bc-4168-a54d-36335bc41cb4')
            //        "
            //    );
        }
        
        public override void Down()
        {
        }
    }
}
