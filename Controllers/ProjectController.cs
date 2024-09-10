using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
