using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
namespace TaskManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext db;

        public UserController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowProfile()
        {
            if(HttpContext.Session.GetString("UserEmail") == null || HttpContext.Session.GetString("UserPassword") == null)
            {
                //the user is not logged
                return RedirectToAction("Index", "Home");
            }
            User? u = await db.Users.SingleOrDefaultAsync(a => a.UserEmail == HttpContext.Session.GetString("UserEmail"));
            if (u == null || u.UserPassword != HttpContext.Session.GetString("UserPassword"))
            {
                // imediately sign out and make the user sign in again
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }




    }
}
