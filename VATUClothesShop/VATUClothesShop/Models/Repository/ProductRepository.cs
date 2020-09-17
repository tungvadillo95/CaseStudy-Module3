using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;

        public ProductRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return vATUShopDbContext.Brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return vATUShopDbContext.Categories;
        }
    }
}
