using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            return View();
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

            return View();
        }
    }
}
