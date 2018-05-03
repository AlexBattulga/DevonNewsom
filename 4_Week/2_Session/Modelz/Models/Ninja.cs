using System;
using System.ComponentModel.DataAnnotations;

namespace Modelz.Models
{
    public class Ninja
    {
        public int NinjaId {get;set;}
        [Required]
        [Display(Name="First Name")]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Required]
        public string Location {get;set;}
        [Range(0, Int32.MaxValue)]
        public int Age {get;set;}
        public DateTime DOB {get;set;}

    }
}
