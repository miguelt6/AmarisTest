namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyDataBaseData : DbMigration
    {
        public override void Up()
        {
            Sql("delete from [Developers] DBCC CHECKIDENT([Developers],RESEED,0)");
            Sql("truncate table [DevelopersStacks]");
            Sql("truncate table [DevelopersWebTechnologies]");
        }

        public override void Down()
        {
        }
    }
}
