namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TraineeCourses", new[] { "Trainee_Id" });
            DropColumn("dbo.TraineeCourses", "TraineeID");
            RenameColumn(table: "dbo.TraineeCourses", name: "Trainee_Id", newName: "TraineeID");
            AlterColumn("dbo.TraineeCourses", "TraineeID", c => c.String(maxLength: 128));
            CreateIndex("dbo.TraineeCourses", "TraineeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TraineeCourses", new[] { "TraineeID" });
            AlterColumn("dbo.TraineeCourses", "TraineeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TraineeCourses", name: "TraineeID", newName: "Trainee_Id");
            AddColumn("dbo.TraineeCourses", "TraineeID", c => c.Int(nullable: false));
            CreateIndex("dbo.TraineeCourses", "Trainee_Id");
        }
    }
}
