using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VATUClothesShop.Models;
using VATUClothesShop.Repository;

namespace VATUClothesShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = productRepository.GetProducts();
            return View(products);
        }
    }
}
