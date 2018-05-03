using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelz.Models;

namespace Modelz.Controllers
{
    public class HomeController : Controller
    {
        public List<Ninja> NinjaTurtles
        {
            get 
            {
                return new List<Ninja>()
                {
                    new Ninja()
                    {
                        FirstName = "Leonardo",
                        LastName = "Ninja Turtle",
                        Location = "New York City",
                    },
                    new Ninja()
                    {
                        FirstName = "Donatello",
                        LastName = "Ninja Turtle",
                        Location = "New York City",
                    },
                    new Ninja()
                    {
                        FirstName = "Michaelangello",
                        LastName = "Ninja Turtle",
                        Location = "New York City",
                    },
                    new Ninja()
                    {
                        FirstName = "Raphiel",
                        LastName = "Ninja Turtle",
                        Location = "New York City",
                    },
                };
            }
        }
        [HttpGet("")]
        public IActionResult Index()
        {
           
            return View(NinjaTurtles.First());
        }
        [HttpPost("create")]
        public IActionResult Create(Ninja model)
        {
            if(model.Location == "Seattle")
                ModelState.AddModelError("Location", "No Seattles allowed");

            if(ModelState.IsValid)
                return Json(model);

            return View("Index");        
        }
        [HttpGet("show")]
        public IActionResult Show()
        {
            Ninja model = new Ninja()
            {
                FirstName = "Timmy",
                LastName = "Whaevet",
                Location = "Tacoma"
            };
            return View(model);
        }
        [HttpGet("ninjas")]
        public IActionResult Ninjas()
        {
            return View(NinjaTurtles);
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View(new DashboardModel(){

                AllNinjas = NinjaTurtles,
                LoggedNinja = NinjaTurtles.First()
            });
        }
    }
}
