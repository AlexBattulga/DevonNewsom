using System.Collections.Generic;

namespace ViewModelsAdv.Models
{
    public class IndexViewModel
    {
        public Dojo NewDojo {get;set;}
        public Ninja NewNinja {get;set;}
        public List<Dictionary<string, object>> Dojos {get;set;}
    }
}
