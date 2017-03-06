namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Like3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "PostLike_id", "dbo.PostLikes");
            DropForeignKey("dbo.Users", "PostLike_id", "dbo.PostLikes");
            DropIndex("dbo.Posts", new[] { "PostLike_id" });
            DropIndex("dbo.Users", new[] { "PostLike_id" });
            AddColumn("dbo.PostLikes", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.PostLikes", "PostID", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "PostLike_id");
            DropColumn("dbo.Users", "PostLike_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PostLike_id", c => c.Int());
            AddColumn("dbo.Posts", "PostLike_id", c => c.Int());
            DropColumn("dbo.PostLikes", "PostID");
            DropColumn("dbo.PostLikes", "UserID");
            CreateIndex("dbo.Users", "PostLike_id");
            CreateIndex("dbo.Posts", "PostLike_id");
            AddForeignKey("dbo.Users", "PostLike_id", "dbo.PostLikes", "id");
            AddForeignKey("dbo.Posts", "PostLike_id", "dbo.PostLikes", "id");
        }
    }
}
