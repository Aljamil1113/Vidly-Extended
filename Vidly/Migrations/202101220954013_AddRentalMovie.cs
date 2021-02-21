namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        RentalId = c.Int(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.RentalId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Rentals", t => t.RentalId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.RentalId);
            
            CreateTable(
                "dbo.RentalMovie1",
                c => new
                    {
                        Rental_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rental_Id, t.Movie_Id })
                .ForeignKey("dbo.Rentals", t => t.Rental_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Rental_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Rentals", "DateReturned");
            DropColumn("dbo.Rentals", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropForeignKey("dbo.RentalMovies", "RentalId", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.RentalMovie1", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentalMovie1", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.RentalMovie1", new[] { "Movie_Id" });
            DropIndex("dbo.RentalMovie1", new[] { "Rental_Id" });
            DropIndex("dbo.RentalMovies", new[] { "RentalId" });
            DropIndex("dbo.RentalMovies", new[] { "MovieId" });
            DropTable("dbo.RentalMovie1");
            DropTable("dbo.RentalMovies");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
