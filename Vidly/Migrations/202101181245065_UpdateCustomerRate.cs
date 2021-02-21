namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerRate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DiscountRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DiscountRate", c => c.Int());
        }
    }
}
