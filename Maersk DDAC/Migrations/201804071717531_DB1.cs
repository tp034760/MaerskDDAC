namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Docks", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Docks", "Schedule_ScheduleID1", "dbo.Schedules");
            DropForeignKey("dbo.Ships", "Schedule_ScheduleID", "dbo.Schedules");
            DropIndex("dbo.Docks", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Docks", new[] { "Schedule_ScheduleID1" });
            DropIndex("dbo.Ships", new[] { "Schedule_ScheduleID" });
            CreateTable(
                "dbo.DockDocks",
                c => new
                    {
                        Dock_DockID = c.Int(nullable: false),
                        Dock_DockID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dock_DockID, t.Dock_DockID1 })
                .ForeignKey("dbo.Docks", t => t.Dock_DockID)
                .ForeignKey("dbo.Docks", t => t.Dock_DockID1)
                .Index(t => t.Dock_DockID)
                .Index(t => t.Dock_DockID1);
            
            AddColumn("dbo.Schedules", "Ship_ShipID", c => c.Int());
            CreateIndex("dbo.Schedules", "Ship_ShipID");
            AddForeignKey("dbo.Schedules", "Ship_ShipID", "dbo.Ships", "ShipID");
            DropColumn("dbo.Docks", "Schedule_ScheduleID");
            DropColumn("dbo.Docks", "Schedule_ScheduleID1");
            DropColumn("dbo.Ships", "Schedule_ScheduleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "Schedule_ScheduleID", c => c.Int());
            AddColumn("dbo.Docks", "Schedule_ScheduleID1", c => c.Int());
            AddColumn("dbo.Docks", "Schedule_ScheduleID", c => c.Int());
            DropForeignKey("dbo.Schedules", "Ship_ShipID", "dbo.Ships");
            DropForeignKey("dbo.DockDocks", "Dock_DockID1", "dbo.Docks");
            DropForeignKey("dbo.DockDocks", "Dock_DockID", "dbo.Docks");
            DropIndex("dbo.DockDocks", new[] { "Dock_DockID1" });
            DropIndex("dbo.DockDocks", new[] { "Dock_DockID" });
            DropIndex("dbo.Schedules", new[] { "Ship_ShipID" });
            DropColumn("dbo.Schedules", "Ship_ShipID");
            DropTable("dbo.DockDocks");
            CreateIndex("dbo.Ships", "Schedule_ScheduleID");
            CreateIndex("dbo.Docks", "Schedule_ScheduleID1");
            CreateIndex("dbo.Docks", "Schedule_ScheduleID");
            AddForeignKey("dbo.Ships", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
            AddForeignKey("dbo.Docks", "Schedule_ScheduleID1", "dbo.Schedules", "ScheduleID");
            AddForeignKey("dbo.Docks", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
        }
    }
}
