using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amaris.Models
{
    public class WebTechnology
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Developer> Developers { get; set; }
    }
}