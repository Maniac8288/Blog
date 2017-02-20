namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class begin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        NamePost = c.String(),
                        selectedCategory = c.String(),
                        contentPost = c.String(),
                        Tags = c.String(),
                        dateAddPost = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        upload = c.String(),
                        Author = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Datebirth = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Photo = c.String(),
                        Salt = c.String(),
                        Email = c.String(),
                        LastVisit = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        DateRegister = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        StatusUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckEmails",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ConfirmedEmail = c.Boolean(nullable: false),
                        ConfirmationCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserPosts", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.UserPosts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CheckEmails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.UserPosts", new[] { "Post_PostID" });
            DropIndex("dbo.UserPosts", new[] { "User_Id" });
            DropIndex("dbo.CheckEmails", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.UserPosts");
            DropTable("dbo.Roles");
            DropTable("dbo.CheckEmails");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
