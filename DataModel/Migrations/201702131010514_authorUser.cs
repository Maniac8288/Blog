namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Post_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Post_PostID })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Post_PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPosts", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.UserPosts", "User_Id", "dbo.Users");
            DropIndex("dbo.UserPosts", new[] { "Post_PostID" });
            DropIndex("dbo.UserPosts", new[] { "User_Id" });
            DropTable("dbo.UserPosts");
        }
    }
}
