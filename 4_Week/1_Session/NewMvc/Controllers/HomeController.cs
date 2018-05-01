using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewMvc.Models;

namespace NewMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> ninjas = DbConnector.Query("SELECT first_name as FORST, last_name, location FROM ninjas");
            ViewBag.Ninjas = ninjas;

            return View();
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost("create")]
        public IActionResult  Create(Ninja ninja)
        {
            // create a ninja!

            string sql = $"INSERT INTO ninjas (first_name, last_name, location) VALUES ('{ninja.first_name}', '{ninja.last_name}', '{ninja.location}');";

            DbConnector.Execute(sql);

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
