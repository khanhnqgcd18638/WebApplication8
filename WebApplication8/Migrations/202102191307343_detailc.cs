namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Detail");
        }
    }
}
