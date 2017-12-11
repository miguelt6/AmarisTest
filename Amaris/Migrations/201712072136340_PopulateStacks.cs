namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStacks : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Stacks (Name) Values('FrontEnd')");
            Sql("INSERT into Stacks (Name) Values('BackEnd')");
            Sql("INSERT into Stacks (Name) Values('FullStack')");
            Sql("INSERT into Stacks (Name) Values('DevOps')");
        }
        
        public override void Down()
        {
        }
    }
}
