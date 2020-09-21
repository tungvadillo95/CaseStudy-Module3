using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;

namespace VATUClothesShop.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;
        public BrandRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return vATUShopDbContext.Brands;
        }
    }
}
