namespace SchoolDistrictMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Teachers", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "ClassId" });
            DropIndex("dbo.Teachers", new[] { "SchoolId" });
            AlterColumn("dbo.Classes", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "ClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teachers", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "TeacherId");
            CreateIndex("dbo.Enrollments", "StudentId");
            CreateIndex("dbo.Enrollments", "ClassId");
            CreateIndex("dbo.Teachers", "SchoolId");
            AddForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes", "Id");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Enrollments", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Teachers", "SchoolId", "dbo.Schools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes");
            DropIndex("dbo.Teachers", new[] { "SchoolId" });
            DropIndex("dbo.Enrollments", new[] { "ClassId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            AlterColumn("dbo.Teachers", "SchoolId", c => c.Int());
            AlterColumn("dbo.Enrollments", "ClassId", c => c.Int());
            AlterColumn("dbo.Enrollments", "StudentId", c => c.Int());
            AlterColumn("dbo.Classes", "TeacherId", c => c.Int());
            CreateIndex("dbo.Teachers", "SchoolId");
            CreateIndex("dbo.Enrollments", "ClassId");
            CreateIndex("dbo.Enrollments", "StudentId");
            CreateIndex("dbo.Classes", "TeacherId");
            AddForeignKey("dbo.Teachers", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Enrollments", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes", "Id");
        }
    }
}
