using System.Collections.Generic;
using Modelz.Models;

namespace Modelz
{
    public class DashboardModel
    {
        public Ninja LoggedNinja {get;set;}
        public List<Ninja> AllNinjas {get;set;}

    }
}