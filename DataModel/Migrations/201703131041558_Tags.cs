namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_PostID })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagPosts", new[] { "Post_PostID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.Tags");
        }
    }
}
