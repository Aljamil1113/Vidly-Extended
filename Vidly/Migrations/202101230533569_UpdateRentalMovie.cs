namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentalMovie1", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovie1", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.RentalMovie1", new[] { "Rental_Id" });
            DropIndex("dbo.RentalMovie1", new[] { "Movie_Id" });
            DropTable("dbo.RentalMovie1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentalMovie1",
                c => new
                    {
                        Rental_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rental_Id, t.Movie_Id });
            
            CreateIndex("dbo.RentalMovie1", "Movie_Id");
            CreateIndex("dbo.RentalMovie1", "Rental_Id");
            AddForeignKey("dbo.RentalMovie1", "Movie_Id", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.RentalMovie1", "Rental_Id", "dbo.Rentals", "RentalId", cascadeDelete: true);
        }
    }
}
