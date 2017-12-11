using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amaris.Models
{
    public class DBInitializer : System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var stacks = new List<Stack>
            {
                new Stack {Name="FrontEnd"},
                new Stack {Name="BackEnd"},
                new Stack {Name="FullStack"},
                new Stack {Name="DevOps"}
            };
            stacks.ForEach(s => context.Stacks.Add(s));
            context.SaveChanges();

            var techs = new List<WebTechnology>
            {
                new WebTechnology {Name="PHP"},
                new WebTechnology {Name=".NET"},
                new WebTechnology {Name="Java"},
                new WebTechnology {Name="Angular"},
                new WebTechnology {Name="JavaScript"},
                new WebTechnology {Name="Ruby"}
            };
            techs.ForEach(s => context.WebTechnologies.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}