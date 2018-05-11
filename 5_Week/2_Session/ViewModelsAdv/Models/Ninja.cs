using System.ComponentModel.DataAnnotations;

namespace ViewModelsAdv.Models
{
    public class Ninja
    {
        public int ninja_id {get;set;}
        [Required]
        public string first_name {get;set;}
        public string last_name {get;set;}
        public int dojo_id {get;set;}
    }
}
