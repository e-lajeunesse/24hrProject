namespace _24hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "OwnerId");
        }
    }
}
