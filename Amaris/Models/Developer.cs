using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amaris.Models
{
    public class Developer
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Contact Phone")]
        public string Phone { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        [Display(Name = "Years of Experience")]
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public string Comments { get; set; }

        public IList<WebTechnology> WebTechnologies { get; set; }

        public IList<Stack> Stacks { get; set; }
    }
}