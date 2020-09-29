using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VATUClothesShop.Models;
using VATUClothesShop.Repository;
using System.Web;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository,
                                       IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AddCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var product = productRepository.GetProduct(id);
                List<CartProduct> listCart = new List<CartProduct>()
               {
                   new CartProduct
                   {
                       Product = product,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.ProductId == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new CartProduct
                    {
                        Product = productRepository.GetProduct(id),
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
                //  return Json(cart2);
            }
            TempData["Message"] = "Bạn đã thêm sản phẩm vào giỏ hàng thành công !";
            return Redirect($"~/Product/Details/{id}");

        }
        public IActionResult ListCart()
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCart(int id, int quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (quantity > 0)
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.ProductId == id)
                        {
                            dataCart[i].Quantity = quantity;
                        }
                    }
                    TempData["Message"] = "Cập nhật sản phẩm trong giỏ hàng thành công !";
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                    return Ok(quantity);
                }
                TempData["Message"] = "Cập nhật sản phẩm trong giỏ hàng không thành công !";
                var cart2 = HttpContext.Session.GetString("cart");
                return Ok(quantity);
            }
            return BadRequest();
        }

        public IActionResult DeleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.ProductId == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                if (dataCart.Count == 0)
                {
                    TempData["Message"] = "Bạn đã xóa sản phẩm ở giỏ hàng thành công !";
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return Ok(true);
            }
            return Ok(false);
        }

    }
}
