using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using project1.Models;
using System.Linq;


namespace project1.Controllers {
    public class HomeController : Controller {
        private ProjectContext _context;
        public HomeController(ProjectContext context) {
            _context = context;
        }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            return View();
        }

        [Route("success")]
        public IActionResult Success() {
            List<User> AllUsers = _context.login.ToList();
            ViewBag.AllUsers = AllUsers;
            return View();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model) {
            if (_context.login.Where(u => u.email == model.email).SingleOrDefault() != null) {
                ModelState.AddModelError("email", "Email is taken. Please try another.");
            } else {
                if(ModelState.IsValid) {
                    User NewUser = new User {
                        first_name = model.first_name,
                        last_name = model.last_name,
                        email = model.email,
                        password = model.password
                    };
                    NewUser.created_at = DateTime.Now;
                    NewUser.updated_at = DateTime.Now;
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    User current = _context.login.Where(u => u.email == model.email).SingleOrDefault();
                    HttpContext.Session.SetInt32("UserId", current.id);
                    TempData["message"] = "You have successfully registered!";
                    return RedirectToAction("Success");                    
                } 
            }
            ViewBag.Errors = ModelState.Values;
            return View("Index");
        }
    }
}
