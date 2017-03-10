namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserPosts", newName: "PostUsers");
            DropPrimaryKey("dbo.PostUsers");
            AddPrimaryKey("dbo.PostUsers", new[] { "Post_PostID", "User_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PostUsers");
            AddPrimaryKey("dbo.PostUsers", new[] { "User_Id", "Post_PostID" });
            RenameTable(name: "dbo.PostUsers", newName: "UserPosts");
        }
    }
}
