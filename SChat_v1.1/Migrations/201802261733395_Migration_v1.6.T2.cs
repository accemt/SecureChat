namespace SChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_v16T2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "AuthorID_Id", newName: "Author_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_AuthorID_Id", newName: "IX_Author_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Messages", name: "IX_Author_Id", newName: "IX_AuthorID_Id");
            RenameColumn(table: "dbo.Messages", name: "Author_Id", newName: "AuthorID_Id");
        }
    }
}
