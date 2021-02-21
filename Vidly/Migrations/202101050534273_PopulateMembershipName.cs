namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name = 'Pay As You Go' WHERE ID = 1");
            Sql("UPDATE MembershipTypes set Name = 'Monthly' WHERE ID = 2");
        }
        
        public override void Down()
        {
        }
    }
}
