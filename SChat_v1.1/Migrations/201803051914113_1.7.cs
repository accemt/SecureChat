namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats");
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            DropIndex("dbo.Messages", new[] { "ReceiverChat_Id" });
            AlterColumn("dbo.Messages", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "ReceiverChat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "Author_Id");
            CreateIndex("dbo.Messages", "ReceiverChat_Id");
            AddForeignKey("dbo.Messages", "Author_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats");
            DropForeignKey("dbo.Messages", "Author_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "ReceiverChat_Id" });
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            AlterColumn("dbo.Messages", "ReceiverChat_Id", c => c.Int());
            AlterColumn("dbo.Messages", "Author_Id", c => c.Int());
            CreateIndex("dbo.Messages", "ReceiverChat_Id");
            CreateIndex("dbo.Messages", "Author_Id");
            AddForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats", "Id");
            AddForeignKey("dbo.Messages", "Author_Id", "dbo.Users", "Id");
        }
    }
}
