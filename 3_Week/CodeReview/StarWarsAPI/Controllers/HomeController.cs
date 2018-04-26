using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Index(int id = 3)
        {
            WebRequest.GetStarWarsAPIAsync(id, callback => 
            {

                ViewBag.Char = callback;
            }).Wait();
            if(ViewBag.Char == null)
                ViewBag.Char = new Dictionary<string, object>();
            return View();
        }
    }
}