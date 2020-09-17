using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;

        public ProductRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public int CreateProduct(Product product)
        {
            vATUShopDbContext.Products.Add(product);
            return vATUShopDbContext.SaveChanges();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return vATUShopDbContext.Brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return vATUShopDbContext.Categories;
        }

        public IEnumerable<Product> GetProducts()
        {
            return vATUShopDbContext.Products;
        }

        public DetailProductViewModel Get(int productId)
        {
            var data = (from p in vATUShopDbContext.Products
                        join c in vATUShopDbContext.Categories
                        on p.CategoryId equals c.CategoryId
                        join b in vATUShopDbContext.Brands
                        on p.BrandingId equals b.BrandId
                        where p.ProductId == productId
                        select new DetailProductViewModel()
                        {
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            BrandingName = b.BrandName,
                            Price = p.Price,
                            Description = p.Description,
                            ImagePath = p.ImagePath
                        }).FirstOrDefault();
            return data;
        }
    }
}
