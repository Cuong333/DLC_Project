using DLC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using X.PagedList;
using X.PagedList.Extensions;

namespace DLC_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly DemoDlcContext _db;
        private readonly ILogger<ProductController> _logger;

        public ProductController(DemoDlcContext db, ILogger<ProductController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;

            var listProduct = _db.Products.AsNoTracking().OrderBy(x => x.ProductName);
            IPagedList<Product> pagedList = listProduct.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public IActionResult ProductDetail(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return NotFound();
            }

            var product = _db.Products
                             .Include(p => p.Category)
                             .Include(p => p.Manufacturer)
                             .Include(p => p.Images)
                             .FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} was not found.", productId);
                return NotFound();
            }

            var popularProducts = _db.Products
                                     .Include(p => p.Images)
                                     .Where(p => p.ProductId != productId)
                                     .OrderByDescending(p => p.Price)
                                     .Take(5)
                                     .ToList();

            var viewModel = new ProductDetailViewModel
            {
                Product = product,
                PopularProducts = popularProducts
            };

            return View(viewModel);
        }
    }
}
