using DLC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;
using X.PagedList.Extensions;

namespace DLC_Project.Controllers
{
    public class HomeController : Controller
    {
        DemoDlcContext db = new DemoDlcContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize =8; 
            int pageNumber = page == null || page <= 0 ? 1 : page.Value; 
            
            var listProduct = db.Products.AsNoTracking().OrderBy(x => x.ProductName);

            // Apply pagination using X.PagedList
            IPagedList<Product> pagedList = listProduct.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
