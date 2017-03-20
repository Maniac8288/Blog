namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Answer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Answer");
        }
    }
}
