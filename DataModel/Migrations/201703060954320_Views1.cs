namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Views1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Views");
        }
    }
}
