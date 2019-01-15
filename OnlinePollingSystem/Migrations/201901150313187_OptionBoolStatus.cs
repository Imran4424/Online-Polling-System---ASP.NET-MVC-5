namespace OnlinePollingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionBoolStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "Status");
        }
    }
}
