using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VATUClothesShop.Models;
using VATUClothesShop.Models.Repository;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IProductRepository productRepository,
                               IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var products = productRepository.GetProducts();
            return View(products);
        }
        [Route("Product/Details/{productId}")]
        public ViewResult Details(int productId)
        {
            var detailView = productRepository.Get(productId);
            return View(detailView);
        }
        [HttpGet]
        public ViewResult Create()
        {
            var model = new CreateProductViewModel();
            model.Categories = productRepository.GetCategories();
            model.Brands = productRepository.GetBrands();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if(model.Image != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                    fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Image.CopyTo(fs);
                    }
                }
                var product = new Product()
                {
                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,
                    BrandingId = model.BrandingId,
                    Price = model.Price,
                    Inventory = model.Inventory,
                    Description = model.Description,
                    ImagePath = fileName
                };
                if (productRepository.CreateProduct(product) > 0)
                {
                    return RedirectToAction("Index","Product");
                }
            }
            return View();
        }
    }
}
