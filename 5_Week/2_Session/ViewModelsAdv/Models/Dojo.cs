using System.ComponentModel.DataAnnotations;

namespace ViewModelsAdv.Models
{
    public class Dojo
    {
        public int dojo_id {get;set;}
        [Required]
        [Display(Name="City")]
        public string city {get;set;}
        [Display(Name="Description")]
        [Required]
        public string description {get;set;}
    }
}
