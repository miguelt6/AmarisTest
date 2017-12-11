namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAPI : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DevStacks");
            DropTable("dbo.DevTechs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DevTechs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperId = c.Int(nullable: false),
                        WebTechId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DevStacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperId = c.Int(nullable: false),
                        StackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
