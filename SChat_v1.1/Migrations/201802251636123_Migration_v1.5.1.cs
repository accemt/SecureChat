namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v151 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverChat", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "ChatID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ChatID", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "ReceiverChat");
        }
    }
}
