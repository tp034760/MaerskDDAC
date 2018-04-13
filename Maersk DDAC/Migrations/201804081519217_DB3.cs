namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Dock_DockID1", "dbo.Docks");
            DropForeignKey("dbo.Schedules", "Dock_DockID", "dbo.Docks");
            DropForeignKey("dbo.Schedules", "Ship_ShipID", "dbo.Ships");
            DropIndex("dbo.Schedules", new[] { "Dock_DockID" });
            DropIndex("dbo.Schedules", new[] { "Dock_DockID1" });
            DropIndex("dbo.Schedules", new[] { "Ship_ShipID" });
            RenameColumn(table: "dbo.Schedules", name: "Dock_DockID", newName: "DockID");
            RenameColumn(table: "dbo.Schedules", name: "Ship_ShipID", newName: "ShipID");
            AlterColumn("dbo.Schedules", "DockID", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "ShipID", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "ShipID");
            CreateIndex("dbo.Schedules", "DockID");
            AddForeignKey("dbo.Schedules", "DockID", "dbo.Docks", "DockID", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "ShipID", "dbo.Ships", "ShipID", cascadeDelete: true);
            DropColumn("dbo.Schedules", "Dock_DockID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Dock_DockID1", c => c.Int());
            DropForeignKey("dbo.Schedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Schedules", "DockID", "dbo.Docks");
            DropIndex("dbo.Schedules", new[] { "DockID" });
            DropIndex("dbo.Schedules", new[] { "ShipID" });
            AlterColumn("dbo.Schedules", "ShipID", c => c.Int());
            AlterColumn("dbo.Schedules", "DockID", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "ShipID", newName: "Ship_ShipID");
            RenameColumn(table: "dbo.Schedules", name: "DockID", newName: "Dock_DockID");
            CreateIndex("dbo.Schedules", "Ship_ShipID");
            CreateIndex("dbo.Schedules", "Dock_DockID1");
            CreateIndex("dbo.Schedules", "Dock_DockID");
            AddForeignKey("dbo.Schedules", "Ship_ShipID", "dbo.Ships", "ShipID");
            AddForeignKey("dbo.Schedules", "Dock_DockID", "dbo.Docks", "DockID");
            AddForeignKey("dbo.Schedules", "Dock_DockID1", "dbo.Docks", "DockID");
        }
    }
}
