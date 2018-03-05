namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v16T1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AuthorID_Id", c => c.Int());
            CreateIndex("dbo.Messages", "AuthorID_Id");
            AddForeignKey("dbo.Messages", "AuthorID_Id", "dbo.Users", "Id");
            DropColumn("dbo.Messages", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Author", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "AuthorID_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "AuthorID_Id" });
            DropColumn("dbo.Messages", "AuthorID_Id");
        }
    }
}
