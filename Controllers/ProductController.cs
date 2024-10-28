using DLC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;

namespace DLC_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly DemoDlcContext _db;

        // Injecting the database context using dependency injection
        public ProductController(DemoDlcContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;

            var listProduct = _db.Products.AsNoTracking().OrderBy(x => x.ProductName);

            // Apply pagination using X.PagedList
            IPagedList<Product> pagedList = listProduct.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        // Product Detail action to view specific product details
        public IActionResult ProductDetail()
        {
            return View("~/Views/Product/ProductDetail.cshtml");
        }
    }
}
