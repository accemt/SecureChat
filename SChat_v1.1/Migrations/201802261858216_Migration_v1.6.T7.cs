namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v16T7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverChat_Id", c => c.Int());
            CreateIndex("dbo.Messages", "ReceiverChat_Id");
            AddForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats", "Id");
            DropColumn("dbo.Messages", "Receiver_Id");
            DropColumn("dbo.Messages", "ReceiverType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReceiverType", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "Receiver_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "ReceiverChat_Id", "dbo.Chats");
            DropIndex("dbo.Messages", new[] { "ReceiverChat_Id" });
            DropColumn("dbo.Messages", "ReceiverChat_Id");
        }
    }
}
