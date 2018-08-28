namespace Welic.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 60, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Login");
        }
    }
}
