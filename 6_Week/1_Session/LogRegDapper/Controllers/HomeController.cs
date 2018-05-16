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
        private UserFactory _userFactory;
        public HomeController(UserFactory factory)
        {
            _userFactory = factory;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet("users")]
        public IActionResult Users()
        {
            ViewBag.Users = _userFactory.GetAllUsers();
            ViewBag.UsersOld = DbConnector.Query("SELECT * FROM users_dapper");
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
            if(!_userFactory.EmailIsUnique(newUser.Email))
            {
                ModelState.AddModelError("Email", "Email in use!");
            }
            if(ModelState.IsValid)
            {
                //TODO: Hash newUser.Password
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                //TODO: INSERT USER
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                _userFactory.CreateUser(newUser);
                return RedirectToAction("Index");
            }
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

