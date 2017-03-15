namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Post_PostID = c.Int(nullable: false),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_PostID, t.Comment_Id })
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .Index(t => t.Post_PostID)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.CommentUsers",
                c => new
                    {
                        Comment_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_Id, t.User_Id })
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Comment_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Comments", "Post_PostID");
            DropColumn("dbo.Comments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_Id", c => c.Int());
            AddColumn("dbo.Comments", "Post_PostID", c => c.Int());
            DropForeignKey("dbo.CommentUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CommentUsers", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.PostComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.PostComments", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.CommentUsers", new[] { "User_Id" });
            DropIndex("dbo.CommentUsers", new[] { "Comment_Id" });
            DropIndex("dbo.PostComments", new[] { "Comment_Id" });
            DropIndex("dbo.PostComments", new[] { "Post_PostID" });
            DropTable("dbo.CommentUsers");
            DropTable("dbo.PostComments");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "Post_PostID");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts", "PostID");
        }
    }
}
