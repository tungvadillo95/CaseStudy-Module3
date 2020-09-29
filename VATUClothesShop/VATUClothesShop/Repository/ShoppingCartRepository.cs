using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;

namespace VATUClothesShop.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;

        public ShoppingCartRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public int CreateNormalOrder(Order order)
        {
            vATUShopDbContext.Orders.Add(order);
            return vATUShopDbContext.SaveChanges();
        }

        public int SubtractionWareHouse(int quantity, int productId)
        {
            var product = vATUShopDbContext.Products.Find(productId);
            product.Inventory -= quantity;
            return vATUShopDbContext.SaveChanges();
        }
    }
}
