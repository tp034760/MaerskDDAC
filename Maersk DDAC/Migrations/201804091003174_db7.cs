namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        GoodID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.GoodID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.GoodID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodID = c.Int(nullable: false, identity: true),
                        GoodName = c.String(),
                    })
                .PrimaryKey(t => t.GoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Orders", "GoodID", "dbo.Goods");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "ScheduleID" });
            DropIndex("dbo.Orders", new[] { "GoodID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Goods");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
