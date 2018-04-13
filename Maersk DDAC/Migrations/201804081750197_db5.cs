namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "DepartureTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Schedules", "ArrivalTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "ArrivalTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "DepartureTime", c => c.DateTime(nullable: false));
        }
    }
}
