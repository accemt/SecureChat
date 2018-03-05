namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverChat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReceiverChat");
        }
    }
}
