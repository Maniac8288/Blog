namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "CourseInstructor");
            RenameColumn(table: "dbo.CourseInstructor", name: "User_Id", newName: "CourseID");
            RenameColumn(table: "dbo.CourseInstructor", name: "Role_Id", newName: "InstructorID");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_User_Id", newName: "IX_CourseID");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_Role_Id", newName: "IX_InstructorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_InstructorID", newName: "IX_Role_Id");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_CourseID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.CourseInstructor", name: "InstructorID", newName: "Role_Id");
            RenameColumn(table: "dbo.CourseInstructor", name: "CourseID", newName: "User_Id");
            RenameTable(name: "dbo.CourseInstructor", newName: "UserRoles");
        }
    }
}
