namespace Welic.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crrecao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ebooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Prince = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Theme = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Print = c.String(maxLength: 8000, unicode: false),
                        UrlDestino = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DateRegister = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.EbookClass",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BookId, t.UserId })
                .ForeignKey("dbo.Ebooks", t => t.BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CourseEbook",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.CourseId })
                .ForeignKey("dbo.Ebooks", t => t.BookId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.BookId)
                .Index(t => t.CourseId);
                        
            AddForeignKey("dbo.Schedules", "ScheduleId", "dbo.Ebooks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ebooks", "TeacherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Schedules", "ScheduleId", "dbo.Ebooks");
            DropForeignKey("dbo.CourseEbook", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseEbook", "BookId", "dbo.Ebooks");
            DropForeignKey("dbo.EbookClass", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EbookClass", "BookId", "dbo.Ebooks");
            DropIndex("dbo.CourseEbook", new[] { "CourseId" });
            DropIndex("dbo.CourseEbook", new[] { "BookId" });
            DropIndex("dbo.EbookClass", new[] { "UserId" });
            DropIndex("dbo.EbookClass", new[] { "BookId" });
            DropIndex("dbo.Ebooks", new[] { "TeacherId" });
            DropColumn("dbo.Lives", "DateRegister");
            DropTable("dbo.CourseEbook");
            DropTable("dbo.EbookClass");
            DropTable("dbo.Ebooks");
        }
    }
}
