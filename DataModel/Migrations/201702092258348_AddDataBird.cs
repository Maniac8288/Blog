namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataBird : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "dataBird", c => c.String());
            AddColumn("dbo.Users", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "dataBird");
        }
    }
}
