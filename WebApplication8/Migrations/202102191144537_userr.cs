namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DateofBirth", c => c.String());
            AddColumn("dbo.AspNetUsers", "Education", c => c.String());
            AddColumn("dbo.AspNetUsers", "MainProgrammingLang", c => c.String());
            AddColumn("dbo.AspNetUsers", "ToeicScore", c => c.Single());
            AddColumn("dbo.AspNetUsers", "ExpDetail", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "Education1", c => c.String());
            AddColumn("dbo.AspNetUsers", "WorkPlace", c => c.String());
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Type", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Type");
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropColumn("dbo.AspNetUsers", "WorkPlace");
            DropColumn("dbo.AspNetUsers", "Education1");
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "ExpDetail");
            DropColumn("dbo.AspNetUsers", "ToeicScore");
            DropColumn("dbo.AspNetUsers", "MainProgrammingLang");
            DropColumn("dbo.AspNetUsers", "Education");
            DropColumn("dbo.AspNetUsers", "DateofBirth");
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
