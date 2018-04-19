using System;
using Microsoft.AspNetCore.Mvc;
namespace HelloAspMvc.Controllers
{
    // RESPONDS TO USER INPUT
    // routing....
    public class WhoaController : Controller
    {
        // RENDER VIEW
        // localhost:5000/ GET
        [HttpGet("")]
        public ViewResult Index()
        {
            // Only Index can see this!\
            ViewBag.TimeFromWhoaController = DateTime.Now;

            return View("Index");
        }

        // REDIRECT
        [HttpGet("hello")]
        public IActionResult RedirectStuff()
        {
            System.Console.WriteLine("WE DID IT");
            return RedirectToAction("Index");
        }
        // JSON
        [HttpGet("json")]
        public JsonResult JsonMe()
        {
            object myData = new
            {
                Name = "Devon",
                Words = new string[]
                {
                    "Apple", "shoe", "pizza"
                }
            };
            return Json(myData);
        } 
    }
}