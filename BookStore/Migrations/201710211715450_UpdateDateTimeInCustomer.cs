namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTimeInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthDate", c => c.Int(nullable: false));
        }
    }
}
