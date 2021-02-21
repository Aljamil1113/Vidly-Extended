namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalAmountAmountDiscountRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DiscountRate", c => c.Int());
            AddColumn("dbo.Movies", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Rentals", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Price");
            DropColumn("dbo.Movies", "Amount");
            DropColumn("dbo.Customers", "DiscountRate");
        }
    }
}
