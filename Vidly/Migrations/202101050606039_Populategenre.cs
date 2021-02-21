namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Genres(Id, Name) VALUES (1, 'Action')");
            Sql("INSERT into Genres(Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT into Genres(Id, Name) VALUES (3, 'Family')");
            Sql("INSERT into Genres(Id, Name) VALUES (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
