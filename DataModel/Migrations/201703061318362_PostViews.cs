namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostViews : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Views", newName: "PostViews");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PostViews", newName: "Views");
        }
    }
}
