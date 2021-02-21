namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Rental_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Rental_Id");
            AddForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals", "RentalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.Movies", new[] { "Rental_Id" });
            DropColumn("dbo.Movies", "Rental_Id");
        }
    }
}
