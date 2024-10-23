using Microsoft.AspNetCore.Mvc;

namespace DLC_Project.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
