using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VATUClothesShop.Models;
using VATUClothesShop.Repository;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICatergoryRepository catergoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IOderRepository oderRepository;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AdminController(IProductRepository productRepository,
                               ICatergoryRepository catergoryRepository,
                               IBrandRepository brandRepository,
                               IShoppingCartRepository shoppingCartRepository,
                               IOderRepository oderRepository,
                               SignInManager<ApplicationUser> signInManager)
        {
            this.productRepository = productRepository;
            this.catergoryRepository = catergoryRepository;
            this.brandRepository = brandRepository;
            this.shoppingCartRepository = shoppingCartRepository;
            this.oderRepository = oderRepository;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            var products = new List<DetailProductViewModel>();
            products = productRepository.GetProducts().ToList();
            return View(products);
        }
        //-----------------------BEGIN CATEGORY----------------------------------
        public IActionResult ShowCatergories()
        {
            var catergories = catergoryRepository.GetCategories().ToList();
            return View(catergories);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CatergoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoy = catergoryRepository.CreateCatergory(model);
                if (categoy > 0)
                {
                    return RedirectToAction("ShowCatergories", "Admin");
                }
            }
            return View();
        }
        [Route("/Admin/DeleteCatergory/{categoryId}")]
        public IActionResult DeleteCatergory(int categoryId)
        {
            if (catergoryRepository.DeleteCategory(categoryId))
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("/Admin/EditCatergory/{Id}")]
        public IActionResult EditCatergory(int Id)
        {
            var catergory = catergoryRepository.GetCatergory(Id);
            if (catergory == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", Id);
            }
            return View(catergory);
        }
        [HttpPost]
        public IActionResult EditCatergory(CatergoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editCatergory = catergoryRepository.EditCatergory(model);
                if (editCatergory > 0)
                {
                    return RedirectToAction("ShowCatergories", "Admin");
                }
            }
            return View();
        }
        //-----------------------END CATEGORY----------------------------------

        //-----------------------BEGIN BRAND----------------------------------
        public IActionResult ShowBrands()
        {
            var brands = brandRepository.GetBrands().ToList();
            return View(brands);
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = brandRepository.CreateBrand(model);
                if (brand > 0)
                {
                    return RedirectToAction("ShowBrands", "Admin");
                }
            }
            return View();
        }
        [Route("/Admin/DeleteBrand/{brandId}")]
        public IActionResult DeleteBrand(int brandId)
        {
            if (brandRepository.DeleteBrand(brandId))
            {
                return Ok(true);
            }
            return Ok(false);
        }
        [HttpGet]
        [Route("/Admin/EditBrand/{Id}")]
        public IActionResult EditBrand(int Id)
        {
            var brand = brandRepository.GetBrand(Id);
            if (brand == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", Id);
            }
            return View(brand);
        }
        [HttpPost]
        public IActionResult EditBrand(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editBrand = brandRepository.EditBrand(model);
                if (editBrand > 0)
                {
                    return RedirectToAction("ShowBrands", "Admin");
                }
            }
            return View();
        }
        //-----------------------END BRAND----------------------------------

        //-----------------------BEGIN PRODUCT----------------------------------
        [Route("Admin/DetailsProduct/{productId}")]
        public ViewResult DetailsProduct(int productId)
        {
            var detailView = productRepository.GetProduct(productId);
            return View(detailView);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var model = new CreateProductViewModel();
            model.Categories = catergoryRepository.GetCategories();
            model.Brands = brandRepository.GetBrands();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = productRepository.ConvertProductViewModel(model);
                if (productRepository.CreateProduct(product) > 0)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
        public IActionResult EditProduct(int Id)
        {
            var product = productRepository.GetProduct(Id);
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
        public IActionResult EditProduct(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editProduct = productRepository.EditProduct(model);
                if (editProduct != null)
                {
                    return Redirect("~/Admin/Index");
                }
            }
            return View();
        }

        [Route("/Admin/DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (productRepository.Delete(productId))
            {
                return Ok(true);
            }
            return Ok(false);
        }
        //-----------------------END PRODUCT----------------------------------

        //-----------------------BEGIN ORDER----------------------------------
        [HttpGet]
        public IActionResult CreateNormalOrder()
        {
            var newOrder = new OrderViewModel();
            newOrder.Products = productRepository.GetProducts();
            return View(newOrder);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateNormalOrder(DetailProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    DateCreated = DateTime.Now,
                    ProductId = model.ProductId,
                    NormalOrderAddress = model.NormalOrderAddress,
                    NormalOrderCustomerName = model.NormalOrderCustomerName,
                    NormalOrderPhone = model.NormalOrderPhone,
                    Quantity = model.Quantity,
                    IsNormalOrder = true
                };
                if (shoppingCartRepository.CreateNormalOrder(order) > 0)
                {
                    if(User.IsInRole("System Admin"))
                    {
                        TempData["Message"] = "Bạn đã đặt hàng thành công !";
                        if (shoppingCartRepository.SubtractionWareHouse(model.Quantity, model.ProductId) > 0)
                        {
                            return RedirectToAction("ShowOrders","Admin");
                        }
                    }
                    TempData["Message"] = "Bạn đã đặt hàng thành công";
                    if (shoppingCartRepository.SubtractionWareHouse(model.Quantity, model.ProductId) > 0)
                    {
                        return Redirect($"~/Product/Details/{model.ProductId}");
                    }
                }
            }
            TempData["Message"] = "Thao tác không thành công. Bạn nhập số lượng sản phẩm không hợp lệ !";
            return Redirect($"~/Product/Details/{model.ProductId}");
        }
        public IActionResult ShowOrders()
        {
            var orders = oderRepository.GetOrders().ToList();
            return View(orders);
        }
        [Route("Admin/DetailsOrder/{orderId}")]
        public IActionResult DetailsOrder(int orderId)
        {
            var detailView = oderRepository.GetOrder(orderId);
            return View(detailView);
        }
    
        [Route("/Admin/DeleteOrder/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            if (oderRepository.Delete(orderId))
            {
                TempData["Message"] = $"Bạn đã xóa thành công đơn hàng có ID: {orderId} !";
                return RedirectToAction("ShowOrders", "Admin");
            }
            TempData["Message"] = $"Tao tác xóa đơn hàng có ID: {orderId} không thành công !";
            return RedirectToAction("ShowOrders", "Admin");
        }
        [HttpGet]
        [Route("/Admin/EditNormalOrder/{orderId}")]
        public IActionResult EditNormalOrder(int orderId)
        {
            var orderEdit = oderRepository.GetOrder(orderId);
            if (orderEdit == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", orderId);
            }
            orderEdit.Products = productRepository.GetProducts();
            return View(orderEdit);
        }
        [HttpPost]
        public IActionResult EditNormalOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editOrder = oderRepository.EditNormalOrder(model);
                if (editOrder > 0)
                {
                    TempData["Message"] = "Bạn đã sửa thành công đơn hàng !";
                    return Redirect($"~/Admin/DetailsOrder/{model.OrderId}");
                }
            }
            return View();
        }
        //-----------------------END ORDER----------------------------------
    }
}
