namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalAmountAmountDiscountRate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
