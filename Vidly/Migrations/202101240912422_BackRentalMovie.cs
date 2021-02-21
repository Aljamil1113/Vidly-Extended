namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackRentalMovie : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RentalMovies");

            DropForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.RentalMovies", new[] { "Rental_Id" });
            DropIndex("dbo.RentalMovies", new[] { "Movie_Id" });
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        RentalId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.RentalId, t.MovieId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Rentals", t => t.RentalId, cascadeDelete: true)
                .Index(t => t.RentalId)
                .Index(t => t.MovieId);      
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        Rental_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rental_Id, t.Movie_Id });
            
            DropForeignKey("dbo.RentalMovies", "RentalId", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovies", "MovieId", "dbo.Movies");
            DropIndex("dbo.RentalMovies", new[] { "MovieId" });
            DropIndex("dbo.RentalMovies", new[] { "RentalId" });
            DropTable("dbo.RentalMovies");
            CreateIndex("dbo.RentalMovies", "Movie_Id");
            CreateIndex("dbo.RentalMovies", "Rental_Id");
            AddForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals", "RentalId", cascadeDelete: true);
        }
    }
}
