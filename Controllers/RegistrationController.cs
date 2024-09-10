using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
namespace TaskManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private AppDbContext db;
        public RegistrationController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        //User Registration
        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> Register(User u, IFormCollection f)
        {
            if (HttpContext.Session.GetString("UserEmail") != null && HttpContext.Session.GetString("UserPassword") != null)
            {
                //the user is already logged in
                return RedirectToAction(nameof(HomeController.Index));
            }    
            if (ModelState.IsValid)
            {
                User? currentUser = await db.Users.SingleOrDefaultAsync(a => a.UserEmail == u.UserEmail);
                if (currentUser != null)
                {
                    ModelState.AddModelError("UserEmail", "There Is a User With This Email");
                    return View(u);
                }
                if (f["ConfirmedPassword"] == u.UserPassword)
                {
                    if (u.UserPassword.Length >= 8)
                    {
                        db.Users.Add(u);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Login", "Login");
                    }
                    
                   
                }
                else
                {
                    ViewData["ConfirmedPassword"] = "The PassWord aren't matching";
                    return View(u);
                }
            }
            return View(u);
        }
    }
}
