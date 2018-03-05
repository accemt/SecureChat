namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v141 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Time", c => c.DateTime(nullable: false));
        }
    }
}
