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
        private UserFactory _factory;
        public HomeController(UserFactory factory)
        {
            _factory = factory;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("users")]
        public IActionResult Users()
        {
            ViewBag.Users = _factory.GetAllUsers();
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
            if(!_factory.UniqueEmail(newUser.Email))
            {
                ModelState.AddModelError("Email", "Email is in use!");
            }
            if(ModelState.IsValid)
            {
                //TODO: Hash newUser.Password
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                string hashed = hasher.HashPassword(newUser, newUser.Password);
                newUser.Password = hashed;
                //TODO: INSERT USER
                _factory.CreateUser(newUser);
            }
            return View("Index");
        }
        [HttpGet("users/{id}")]
        public IActionResult ShowUser(int id)
        {
            RegisterUser model = _factory.GetUserById(id);
            return View(model);
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            //TODO: check DB for Email
            if(_factory.UniqueEmail(logUser.Email))
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
            }
            else
            {
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                RegisterUser user = _factory.GetUserByEmail(logUser.Email);
                //TODO: verify hashed PW
                PasswordVerificationResult result = hasher.VerifyHashedPassword(logUser, user.Password, logUser.Password);
                if(result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                }
            }
            if(ModelState.IsValid)
            {
                // Set Session ID
                return RedirectToAction("Index");
            }
            return View("Login");
        }
    }
}

