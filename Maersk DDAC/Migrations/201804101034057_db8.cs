namespace Maersk_DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AssociatedComapany", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AssociatedComapany");
        }
    }
}
