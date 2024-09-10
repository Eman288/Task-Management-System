using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private AppDbContext db;


        public LoginController(AppDbContext db)
        {
            this.db = db;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            string? s = HttpContext.Session.GetString("UserEmail");
            string? pass = HttpContext.Session.GetString("UserPassword");
            if (s != null && pass != null)
            {
                //the user is already logged in
                return RedirectToAction(nameof(Index));
            }
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> Login(User u)
        {
            string? s = HttpContext.Session.GetString("UserEmail");
            string? pass = HttpContext.Session.GetString("UserPassword");
            if (s  != null && pass != null)
            {
                //the user is already logged in
                return RedirectToAction(nameof(HomeController.Index));
            }
            User? currentE = await db.Users.SingleOrDefaultAsync(a => a.UserEmail == u.UserEmail);
            if (currentE == null)
            {
                //return an error message saying "there is no user with this email"
                ModelState.AddModelError("UserEmail", "there is no user with this email");
                return View(nameof(Login), u);
            }
            if (currentE.UserPassword != u.UserPassword)
            {
                //return an error message saying "the password is wrong"
                ModelState.AddModelError("UserPassword", "the password is wrong");
                return View(nameof(Login), u);
            }
            HttpContext.Session.SetString("UserEmail", u.UserEmail);
            HttpContext.Session.SetString("UserPassword", u.UserPassword);
            ViewData["UserEmail"] = u.UserEmail;
            ViewData["UserPassword"] = u.UserPassword;
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index", "Home");
        }
    }
}
