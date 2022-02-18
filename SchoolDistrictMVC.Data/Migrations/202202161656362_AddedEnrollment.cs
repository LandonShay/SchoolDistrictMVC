namespace SchoolDistrictMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnrollment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);
            
            DropColumn("dbo.Students", "Class_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Class_Id", c => c.Int());
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "ClassId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropTable("dbo.Enrollments");
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
        }
    }
}
