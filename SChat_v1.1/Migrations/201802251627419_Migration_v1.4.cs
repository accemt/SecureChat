namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v14 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Messages", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Messages", "Id");
        }
    }
}
