namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTwoColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickup", c => c.String());
            AddColumn("dbo.Customers", "ExtraDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraDate");
            DropColumn("dbo.Customers", "WeeklyPickup");
        }
    }
}
