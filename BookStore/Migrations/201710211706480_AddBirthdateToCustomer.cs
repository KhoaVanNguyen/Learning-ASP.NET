namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
           Sql("UPDATE Customers SET birthDate = CAST('1996-05-25' AS DATETIME) WHERE Id = 5  ");
        }
        
        public override void Down()
        {
        }
    }
}
