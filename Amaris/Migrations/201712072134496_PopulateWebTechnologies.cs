namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWebTechnologies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into WebTechnologies (Name) Values('PHP')");
            Sql("INSERT into WebTechnologies (Name) Values('.NET')");
            Sql("INSERT into WebTechnologies (Name) Values('Java')");
            Sql("INSERT into WebTechnologies (Name) Values('Angular')");
            Sql("INSERT into WebTechnologies (Name) Values('Ruby')");
            Sql("INSERT into WebTechnologies (Name) Values('JavaScript')");
        }
        
        public override void Down()
        {
        }
    }
}
