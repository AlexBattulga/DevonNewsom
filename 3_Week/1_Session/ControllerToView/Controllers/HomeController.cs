using ControllerToView.Models;
using Microsoft.AspNetCore.Mvc;
namespace ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        public static string[] Cities
        {
            get
            {
                return new string[]
                {
                    "Seattle", "San Jose", "Aberdeen", "Tacoma"
                };
            }
        }
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.User = "Pete";
            ViewBag.Cities = Cities;
            // Dictionary<string,object>
           
            return View();
        }
        [HttpPost("strings")]
        public IActionResult NewPerson(string FirstName, string LastName, string Location)
        {
            ViewBag.User = FirstName;
            ViewBag.Person = new Person()
            {
                FirstName = FirstName,
                LastName = LastName,
                Location = Location
            };
            ViewBag.Cities = Cities;

            if(FirstName == "Jason")
                return Json(ViewBag.User);
            return RedirectToAction("Index");
        }
        [HttpPost("person")]
        public IActionResult NewPerson(Person person)
        {
            ViewBag.Person = person;
            ViewBag.User = person.FirstName;
            ViewBag.Cities = Cities;

            if(person.FirstName == "Jason")
                return Json(person);
            return RedirectToAction("Index");
        }

    }
}