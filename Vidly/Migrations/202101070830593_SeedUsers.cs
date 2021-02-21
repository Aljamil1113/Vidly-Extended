namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            //Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'25ec0e67-4cf6-4276-872d-90c3ff5e2636', N'guest@vidly.com', 0, N'ABG6KQCacdzdOUSP5AiEsowfanCtp/qjKifLuk+vbZcuJQINlcUc3VPCXgPjNsy8WQ==', N'a500a5c3-4463-4cc7-bc75-94726be022a0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            //      INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6234db39-c289-4d29-a220-d80ac98661dc', N'admin@vidly.com', 0, N'AD/vXGlh0ocfF/2GB/6vo7o2AtNXmcY5PBLPyz+lxYgSH9DhiBKetXoQrEZZ+XFF7Q==', N'bd8ea863-b103-4d62-b823-dc1e8829a6c1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

            //      INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5449390f-ce5b-4c66-b76f-317776569f25', N'CanManageMovies')

            //      INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6234db39-c289-4d29-a220-d80ac98661dc', N'5449390f-ce5b-4c66-b76f-317776569f25')

            //    ");
        }
        
        public override void Down()
        {
        }
    }
}
