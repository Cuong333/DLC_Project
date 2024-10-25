using Microsoft.AspNetCore.Mvc;

namespace DLC_Project.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
