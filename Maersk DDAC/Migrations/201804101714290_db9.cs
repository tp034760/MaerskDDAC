namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TimeBooked", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TimeBooked");
        }
    }
}
