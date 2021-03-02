namespace _24hr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropColumn("dbo.Reply", "CommentId");
        }
    }
}
