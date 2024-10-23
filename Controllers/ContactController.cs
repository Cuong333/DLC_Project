using Microsoft.AspNetCore.Mvc;

namespace DLC_Project.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
