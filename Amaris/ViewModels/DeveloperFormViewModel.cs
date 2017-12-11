using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amaris.Models;

namespace Amaris.ViewModels
{
    public class DeveloperFormViewModel
    {
        public Developer Developer { get; set; }
        public List<int> WebTechId { get; set; }
        public List<int> StacksId { get; set; }
    }
}