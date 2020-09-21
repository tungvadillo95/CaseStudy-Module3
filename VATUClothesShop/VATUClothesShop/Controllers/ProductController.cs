using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VATUClothesShop.Models;
using VATUClothesShop.Repository;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICatergoryRepository catergoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IProductRepository productRepository,
                               ICatergoryRepository catergoryRepository,
                               IBrandRepository brandRepository,
                               IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.catergoryRepository = catergoryRepository;
            this.brandRepository = brandRepository;
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
        public IActionResult Create()
        {
            var model = new CreateProductViewModel();
            model.Categories = catergoryRepository.GetCategories();
            model.Brands = brandRepository.GetBrands();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = productRepository.ConvertProductViewModel(model);
                if (productRepository.CreateProduct(product) > 0)
                {
                    return RedirectToAction("Index","Product");
                }
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            var product = productRepository.Get(Id);
            if (product == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", Id);
            }
            var productEdit = productRepository.ConvertEditProductViewModel(product);
            productEdit.ProductId = Id;
            productEdit.Brands = brandRepository.GetBrands();
            productEdit.Categories = catergoryRepository.GetCategories();
            return View(productEdit);
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editProduct = productRepository.EditProduct(model);
                if (editProduct != null)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }
    }
}
