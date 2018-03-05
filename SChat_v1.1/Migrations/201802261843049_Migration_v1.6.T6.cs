namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v16T6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Chat_Id", "dbo.Chats");
            DropIndex("dbo.Users", new[] { "Chat_Id" });
            CreateTable(
                "dbo.UserChats",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Chat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Chat_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.Chat_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Chat_Id);
            
            DropColumn("dbo.Users", "Chat_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Chat_Id", c => c.Int());
            DropForeignKey("dbo.UserChats", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.UserChats", "User_Id", "dbo.Users");
            DropIndex("dbo.UserChats", new[] { "Chat_Id" });
            DropIndex("dbo.UserChats", new[] { "User_Id" });
            DropTable("dbo.UserChats");
            CreateIndex("dbo.Users", "Chat_Id");
            AddForeignKey("dbo.Users", "Chat_Id", "dbo.Chats", "Id");
        }
    }
}
