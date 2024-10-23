using Microsoft.AspNetCore.Mvc;

namespace DLC_Project.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
