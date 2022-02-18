namespace SchoolDistrictMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedIds1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "School_Id", "dbo.Schools");
            DropIndex("dbo.Enrollments", new[] { "School_Id" });
            DropColumn("dbo.Enrollments", "School_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "School_Id", c => c.Int());
            CreateIndex("dbo.Enrollments", "School_Id");
            AddForeignKey("dbo.Enrollments", "School_Id", "dbo.Schools", "Id");
        }
    }
}
