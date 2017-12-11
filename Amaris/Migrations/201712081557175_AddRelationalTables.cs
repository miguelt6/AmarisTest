namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationalTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevStacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperId = c.Int(nullable: false),
                        StackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DevTechs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperId = c.Int(nullable: false),
                        WebTechId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevTechs");
            DropTable("dbo.DevStacks");
        }
    }
}
