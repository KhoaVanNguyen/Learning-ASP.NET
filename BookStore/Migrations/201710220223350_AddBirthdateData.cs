namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET birthDate = CAST('1996-11-25' AS DATETIME) WHERE Id = 5  ");
            Sql("UPDATE Customers SET birthDate = CAST('1992-04-25' AS DATETIME) WHERE Id = 6  ");
            Sql("UPDATE Customers SET birthDate = CAST('1991-05-25' AS DATETIME) WHERE Id = 4  ");
        }
        
        public override void Down()
        {
        }
    }
}
