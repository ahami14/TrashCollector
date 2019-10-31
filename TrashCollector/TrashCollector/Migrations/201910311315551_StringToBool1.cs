namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringToBool1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "confirmedPickup", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "confirmedPickup", c => c.Boolean(nullable: false));
        }
    }
}
