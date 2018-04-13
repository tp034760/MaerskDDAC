namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "DockID", "dbo.Docks");
            DropIndex("dbo.Schedules", new[] { "DockID" });
            RenameColumn(table: "dbo.Schedules", name: "DockID", newName: "Arrival_DockID");
            AddColumn("dbo.Schedules", "Departure_DockID", c => c.Int());
            AlterColumn("dbo.Schedules", "Arrival_DockID", c => c.Int());
            CreateIndex("dbo.Schedules", "Arrival_DockID");
            CreateIndex("dbo.Schedules", "Departure_DockID");
            AddForeignKey("dbo.Schedules", "Departure_DockID", "dbo.Docks", "DockID");
            AddForeignKey("dbo.Schedules", "Arrival_DockID", "dbo.Docks", "DockID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Arrival_DockID", "dbo.Docks");
            DropForeignKey("dbo.Schedules", "Departure_DockID", "dbo.Docks");
            DropIndex("dbo.Schedules", new[] { "Departure_DockID" });
            DropIndex("dbo.Schedules", new[] { "Arrival_DockID" });
            AlterColumn("dbo.Schedules", "Arrival_DockID", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "Departure_DockID");
            RenameColumn(table: "dbo.Schedules", name: "Arrival_DockID", newName: "DockID");
            CreateIndex("dbo.Schedules", "DockID");
            AddForeignKey("dbo.Schedules", "DockID", "dbo.Docks", "DockID", cascadeDelete: true);
        }
    }
}
