namespace Amaris.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDevelopers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Developers (FirstName,LastName,Address,Email,Phone,Dob,YearsOfExperience,Comments) values ('Miguel','Suarez','D4','miguel@gmail.com','0834564567','1980-10-10 10:10',3,'Hola Miguel')");
            Sql("INSERT into Developers (FirstName,LastName,Address,Email,Phone,Dob,YearsOfExperience,Comments) values ('Alfonso','Nunez','D5','alfonso@gmail.com','0834564567','1980-10-10 10:10',3,'Hola Alfonso')");
        }
        
        public override void Down()
        {
        }
    }
}
