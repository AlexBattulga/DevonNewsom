using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(RegisterUser newUser)
        {
            if(ModelState.IsValid)
            {
                //TODO: check uniqueness of newUser.Email
                string query = $"SELECT * FROM users WHERE email = '{newUser.Email}'";

                List<Dictionary<string, object>> result = DbConnector.Query(query);
                bool isUnique = (result.Count < 1);

                if(isUnique)
                {
                    //TODO: Hash newUser.Password
                    PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                    string hashedPW = hasher.HashPassword(newUser, newUser.Password);

                    //TODO: INSERT USER

                }
                else
                    ModelState.AddModelError("Email", "Email in in use!");

            }
            if(ModelState.IsValid)
                return RedirectToAction("Index");

            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            if(ModelState.IsValid)
            {
                //TODO: check DB for Email
                string query = $"SELECT * FROM users WHERE email = '{logUser.Email}'";

                result = DbConnector.Query(query);
                bool isUnique = (result.Count < 1);

                if(isUnique)
                {
                    ModelState.AddModelError("Email", "Invalid email/password");
                }
                else
                {
                    //TODO: verify hashed PW
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();

                    string storedPW = (string)result.First()["password"];

                    PasswordVerificationResult pwResult = hasher.VerifyHashedPassword(logUser, storedPW, logUser.Password);

                    if(pwResult == PasswordVerificationResult.Failed)
                        ModelState.AddModelError("Email", "Invalid email/password");

                }

            }
            if(ModelState.IsValid)
            {
                // Set Session ID
                int userId = (int)result.First()["user_id"];

                HttpContext.Session.SetInt32("id", userId);
                return RedirectToAction("Index");
            }
            return View("Login");
        }
    }
}
