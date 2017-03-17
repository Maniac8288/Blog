namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PareantId", c => c.Int());
            CreateIndex("dbo.Comments", "PareantId");
            AddForeignKey("dbo.Comments", "PareantId", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PareantId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "PareantId" });
            DropColumn("dbo.Comments", "PareantId");
        }
    }
}
