namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherStringToBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "confirmedPickup", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "confirmedPickup", c => c.String());
        }
    }
}
