using Microsoft.AspNetCore.Mvc;

namespace DLC_Project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ProductDetail()
        //{
        //    return View("~/Views/Product/ProductDetail.cshtml");
        //}
    }
}
