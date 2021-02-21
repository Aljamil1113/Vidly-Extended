namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentLimitAndIsDelinquentToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDelinquent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "RentLimit", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "RentLimit");
            DropColumn("dbo.Customers", "IsDelinquent");
        }
    }
}
