using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace SessionLec.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            // initialization
            // check and see if my value is in session!

            int? count = HttpContext.Session.GetInt32("count");
            List<string> names = HttpContext.Session.GetObjectFromJson<List<string>>("names");

            if(count == null)
            {
                count = 0;
                HttpContext.Session.SetInt32("count", 0);
            }

            if(names == null)
                names = new List<string>();

            HttpContext.Session.SetInt32("count", (int)count);
            HttpContext.Session.SetObjectAsJson("names", names);
            ViewBag.Count = count;
            ViewBag.Names = names;

            return View();
        }

        [HttpGet("counter")]
        public IActionResult Count()
        {
            // what should we do?
            // get count
            int? count = HttpContext.Session.GetInt32("count");
            // increment count
            count++;
            // put count right back in session
            HttpContext.Session.SetInt32("count", (int)count);
            return RedirectToAction("Index");
        }
        [HttpGet("reset")]
        public IActionResult ResetSessionCount()
        {
            return RedirectToAction("Index");
        }
        [HttpPost("name")]
        public IActionResult Name(string name)
        {
             // what should we do?
            // grab names
            List<string> names = HttpContext.Session.GetObjectFromJson<List<string>>("names");

            // add new name
            names.Add(name);

            // put names back in session
            HttpContext.Session.SetObjectAsJson("names", names);
         
            return RedirectToAction("Index");
        }
    }
}
