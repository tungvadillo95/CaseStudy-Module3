using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;

namespace VATUClothesShop.Repository
{
    public class CatergoryRepository : ICatergoryRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;
        public CatergoryRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }
        public IEnumerable<Category> GetCategories()
        {
            return vATUShopDbContext.Categories;
        }
    }
}
