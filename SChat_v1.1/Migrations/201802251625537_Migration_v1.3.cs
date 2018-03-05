namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v13 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Receivers", newName: "Chats");
            DropForeignKey("dbo.Messages", "ReceiverChat", "dbo.Receivers");
            DropIndex("dbo.Chats", new[] { "Chat_Id" });
            DropIndex("dbo.Messages", new[] { "ReceiverChat" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PasswordHash = c.String(),
                        token = c.String(),
                        tokenExpiry = c.DateTime(),
                        Chat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Chat_Id);
            
            AddColumn("dbo.Messages", "ReceiverType", c => c.Int(nullable: false));
            DropColumn("dbo.Chats", "Name");
            DropColumn("dbo.Chats", "PasswordHash");
            DropColumn("dbo.Chats", "token");
            DropColumn("dbo.Chats", "tokenExpiry");
            DropColumn("dbo.Chats", "Discriminator");
            DropColumn("dbo.Chats", "Chat_Id");
            DropColumn("dbo.Messages", "ReceiverChat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReceiverChat", c => c.Int());
            AddColumn("dbo.Chats", "Chat_Id", c => c.Int());
            AddColumn("dbo.Chats", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Chats", "tokenExpiry", c => c.DateTime());
            AddColumn("dbo.Chats", "token", c => c.String());
            AddColumn("dbo.Chats", "PasswordHash", c => c.String());
            AddColumn("dbo.Chats", "Name", c => c.String());
            DropIndex("dbo.Users", new[] { "Chat_Id" });
            DropColumn("dbo.Messages", "ReceiverType");
            DropTable("dbo.Users");
            CreateIndex("dbo.Messages", "ReceiverChat");
            CreateIndex("dbo.Chats", "Chat_Id");
            AddForeignKey("dbo.Messages", "ReceiverChat", "dbo.Receivers", "MessageId");
            RenameTable(name: "dbo.Chats", newName: "Receivers");
        }
    }
}
