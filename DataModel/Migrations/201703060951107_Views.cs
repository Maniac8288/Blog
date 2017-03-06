namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Views : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CountViews", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CountViews");
        }
    }
}
