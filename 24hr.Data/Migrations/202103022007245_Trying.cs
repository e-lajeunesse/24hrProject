namespace _24hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trying : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "Reply");
        }
    }
}
