namespace SchoolDistrictMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        TeacherId = c.Int(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SchoolId);
            
            AddColumn("dbo.Students", "Class_Id", c => c.Int());
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropColumn("dbo.Students", "Class_Id");
            DropTable("dbo.Classes");
        }
    }
}
