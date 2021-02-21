namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalMovieRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentalMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovies", "RentalId", "dbo.Rentals");
            DropIndex("dbo.Movies", new[] { "Rental_Id" });
            DropIndex("dbo.RentalMovies", new[] { "MovieId" });
            DropIndex("dbo.RentalMovies", new[] { "RentalId" });
            DropColumn("dbo.Movies", "Rental_Id");
            DropTable("dbo.RentalMovies");

            CreateTable(
                "dbo.RentalMovies",
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
            
          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        RentalId = c.Int(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.RentalId });
            
            AddColumn("dbo.Movies", "Rental_Id", c => c.Int());
            DropForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.RentalMovies", new[] { "Movie_Id" });
            DropIndex("dbo.RentalMovies", new[] { "Rental_Id" });
            DropTable("dbo.RentalMovies");
            CreateIndex("dbo.RentalMovies", "RentalId");
            CreateIndex("dbo.RentalMovies", "MovieId");
            CreateIndex("dbo.Movies", "Rental_Id");
            AddForeignKey("dbo.RentalMovies", "RentalId", "dbo.Rentals", "RentalId", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals", "RentalId");
            AddForeignKey("dbo.RentalMovies", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
