using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;
        public BrandRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public int CreateBrand(BrandViewModel model)
        {
            var brand = new Brand()
            {
                BrandName = model.BrandName
            };
            vATUShopDbContext.Brands.Add(brand);
            return vATUShopDbContext.SaveChanges();
        }

        public bool DeleteBrand(int Id)
        {
            var delBrand = vATUShopDbContext.Brands.Find(Id);
            if (delBrand != null)
            {
                delBrand.IsDelete = true;
                var result = vATUShopDbContext.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public int EditBrand(BrandViewModel model)
        {
            var editBrand = vATUShopDbContext.Brands.Find(model.BrandId);
            editBrand.BrandName = model.BrandName;
            return vATUShopDbContext.SaveChanges();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return vATUShopDbContext.Brands;
        }

        public BrandViewModel GetBrand(int Id)
        {
            var brand = (from b in vATUShopDbContext.Brands
                             where b.BrandId == Id
                             select (new BrandViewModel()
                             {
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 IsDelete = b.IsDelete
                             })).FirstOrDefault();
            return brand;
        }
    }
}
