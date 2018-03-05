namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Chats", newName: "Receivers");
            //DropIndex("dbo.Users", new[] { "Chat_Id" });
            AddColumn("dbo.Receivers", "Name", c => c.String());
            AddColumn("dbo.Receivers", "PasswordHash", c => c.String());
            AddColumn("dbo.Receivers", "token", c => c.String());
            AddColumn("dbo.Receivers", "tokenExpiry", c => c.DateTime());
            AddColumn("dbo.Receivers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Receivers", "Chat_Id", c => c.Int());
            CreateIndex("dbo.Receivers", "Chat_Id");
            DropColumn("dbo.Messages", "ReceiverChat");
            //DropTable("dbo.Users");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "ReceiverChat", c => c.Int(nullable: false));
            DropIndex("dbo.Receivers", new[] { "Chat_Id" });
            DropColumn("dbo.Receivers", "Chat_Id");
            DropColumn("dbo.Receivers", "Discriminator");
            DropColumn("dbo.Receivers", "tokenExpiry");
            DropColumn("dbo.Receivers", "token");
            DropColumn("dbo.Receivers", "PasswordHash");
            DropColumn("dbo.Receivers", "Name");
            CreateIndex("dbo.Users", "Chat_Id");
            RenameTable(name: "dbo.Receivers", newName: "Chats");
        }
    }
}
