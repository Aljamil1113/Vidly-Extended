namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Id", newName: "CustomerId");
            RenameColumn(table: "dbo.MembershipTypes", name: "Id", newName: "MembershipTypeId");
            RenameColumn(table: "dbo.Genres", name: "Id", newName: "GenreId");
            RenameColumn(table: "dbo.Movies", name: "Id", newName: "MovieId");
            RenameColumn(table: "dbo.Rentals", name: "Id", newName: "RentalId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Rentals", name: "RentalId", newName: "Id");
            RenameColumn(table: "dbo.Movies", name: "MovieId", newName: "Id");
            RenameColumn(table: "dbo.Genres", name: "GenreId", newName: "Id");
            RenameColumn(table: "dbo.MembershipTypes", name: "MembershipTypeId", newName: "Id");
            RenameColumn(table: "dbo.Customers", name: "CustomerId", newName: "Id");
        }
    }
}
