namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorID", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Author", c => c.String());
            DropColumn("dbo.Posts", "AuthorID");
        }
    }
}
