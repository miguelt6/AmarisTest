namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRelationalTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into DevStacks (DeveloperId, StackId) values (1,1)");
            Sql("INSERT into DevStacks (DeveloperId, StackId) values (1,3)");
            Sql("INSERT into DevStacks (DeveloperId, StackId) values (2,1)");
            Sql("INSERT into DevStacks (DeveloperId, StackId) values (2,2)");
            Sql("INSERT into DevStacks (DeveloperId, StackId) values (2,4)");

            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (1,1)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (1,3)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (2,1)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (2,2)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (2,4)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (1,4)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (2,5)");
            Sql("INSERT into DevTechs (DeveloperId, WebTechId) values (2,6)");
        }

        public override void Down()
        {
        }
    }
}
