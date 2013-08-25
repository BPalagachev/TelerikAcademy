namespace Students.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Marks", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "School_Id" });
            DropForeignKey("dbo.Marks", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "School_Id", "dbo.Schools");
            DropTable("dbo.Marks");
            DropTable("dbo.Schools");
            DropTable("dbo.Students");
        }
    }
}
