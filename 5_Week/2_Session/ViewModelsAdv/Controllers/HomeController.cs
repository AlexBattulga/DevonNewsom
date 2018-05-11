using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelsAdv.Models;

namespace ViewModelsAdv.Controllers
{
    public class HomeController : Controller
    {
        private List<Dictionary<string,object>> _allDojos
        {
            get { return DbConnector.Query("SELECT * FROM dojos"); }
        }
        private IndexViewModel _viewModel
        {
            get { return new IndexViewModel()
            {
                Dojos = _allDojos
            };}
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            
            return View(_viewModel);
        }
        [HttpPost("dojo/create")]
        public IActionResult CreateDojo(IndexViewModel model)
        {
            Dojo newDojo = model.NewDojo;
            if(ModelState.IsValid)
            {
                // create a dojo, insert query
                return RedirectToAction("Index");
            }
           
            return View("Index", _viewModel);
        }
        [HttpPost("ninja/create")]
        public IActionResult CreateNinja(IndexViewModel model)
        {
            Ninja newNinja = model.NewNinja;
            if(ModelState.IsValid)
            {
                // create a ninja, insert query
                return RedirectToAction("Index");
            }
            
            return View("Index", _viewModel);
        }
    }
}
