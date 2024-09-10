using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
