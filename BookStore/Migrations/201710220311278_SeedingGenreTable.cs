namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Adventure')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'Crime')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (5,'Drama')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (6,'Fantasy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (7,'Historical')");
        }
        
        public override void Down()
        {
        }
    }
}
