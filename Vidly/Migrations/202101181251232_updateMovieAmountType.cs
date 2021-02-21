namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieAmountType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Amount", c => c.Int(nullable: false));
        }
    }
}
