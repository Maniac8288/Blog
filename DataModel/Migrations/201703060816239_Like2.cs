namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Like2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Posts", "PostLike_id", c => c.Int());
            AddColumn("dbo.Users", "PostLike_id", c => c.Int());
            CreateIndex("dbo.Posts", "PostLike_id");
            CreateIndex("dbo.Users", "PostLike_id");
            AddForeignKey("dbo.Posts", "PostLike_id", "dbo.PostLikes", "id");
            AddForeignKey("dbo.Users", "PostLike_id", "dbo.PostLikes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PostLike_id", "dbo.PostLikes");
            DropForeignKey("dbo.Posts", "PostLike_id", "dbo.PostLikes");
            DropIndex("dbo.Users", new[] { "PostLike_id" });
            DropIndex("dbo.Posts", new[] { "PostLike_id" });
            DropColumn("dbo.Users", "PostLike_id");
            DropColumn("dbo.Posts", "PostLike_id");
            DropTable("dbo.PostLikes");
        }
    }
}
