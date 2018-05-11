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
            //TODO: check uniqueness of newUser.Email
            //TODO: Hash newUser.Password
            //TODO: INSERT USER

            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            //TODO: check DB for Email
            //TODO: verify hashed PW
            // Set Session ID
            return View("Login");
        }
    }
}

