namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ucourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TraineeID = c.Int(nullable: false),
                        Trainee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Trainee_Id)
                .Index(t => t.CourseID)
                .Index(t => t.Trainee_Id);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerCourses", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TraineeCourses", "Trainee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "CourseId" });
            DropIndex("dbo.TrainerCourses", new[] { "TrainerId" });
            DropIndex("dbo.TraineeCourses", new[] { "Trainee_Id" });
            DropIndex("dbo.TraineeCourses", new[] { "CourseID" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.TraineeCourses");
        }
    }
}
