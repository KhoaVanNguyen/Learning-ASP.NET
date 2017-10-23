namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthDate", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "birthDate");
        }
    }
}
