namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v16T5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            AddColumn("dbo.Chats", "Name", c => c.String());
            AddColumn("dbo.Messages", "ReceiverChat", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "User_Id");
            DropColumn("dbo.Messages", "ReceiverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReceiverID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            DropColumn("dbo.Messages", "ReceiverChat");
            DropColumn("dbo.Chats", "Name");
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
    }
}
