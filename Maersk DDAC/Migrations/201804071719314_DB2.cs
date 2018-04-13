namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DockDocks", "Dock_DockID", "dbo.Docks");
            DropForeignKey("dbo.DockDocks", "Dock_DockID1", "dbo.Docks");
            DropIndex("dbo.DockDocks", new[] { "Dock_DockID" });
            DropIndex("dbo.DockDocks", new[] { "Dock_DockID1" });
            AddColumn("dbo.Schedules", "Dock_DockID", c => c.Int());
            AddColumn("dbo.Schedules", "Dock_DockID1", c => c.Int());
            CreateIndex("dbo.Schedules", "Dock_DockID");
            CreateIndex("dbo.Schedules", "Dock_DockID1");
            AddForeignKey("dbo.Schedules", "Dock_DockID", "dbo.Docks", "DockID");
            AddForeignKey("dbo.Schedules", "Dock_DockID1", "dbo.Docks", "DockID");
            DropTable("dbo.DockDocks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DockDocks",
                c => new
                    {
                        Dock_DockID = c.Int(nullable: false),
                        Dock_DockID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dock_DockID, t.Dock_DockID1 });
            
            DropForeignKey("dbo.Schedules", "Dock_DockID1", "dbo.Docks");
            DropForeignKey("dbo.Schedules", "Dock_DockID", "dbo.Docks");
            DropIndex("dbo.Schedules", new[] { "Dock_DockID1" });
            DropIndex("dbo.Schedules", new[] { "Dock_DockID" });
            DropColumn("dbo.Schedules", "Dock_DockID1");
            DropColumn("dbo.Schedules", "Dock_DockID");
            CreateIndex("dbo.DockDocks", "Dock_DockID1");
            CreateIndex("dbo.DockDocks", "Dock_DockID");
            AddForeignKey("dbo.DockDocks", "Dock_DockID1", "dbo.Docks", "DockID");
            AddForeignKey("dbo.DockDocks", "Dock_DockID", "dbo.Docks", "DockID");
        }
    }
}
