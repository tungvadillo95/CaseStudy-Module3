using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductRepository(VATUShopDbContext vATUShopDbContext,
                                 IWebHostEnvironment webHostEnvironment)
        {
            this.vATUShopDbContext = vATUShopDbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public int CreateProduct(Product product)
        {
            vATUShopDbContext.Products.Add(product);
            return vATUShopDbContext.SaveChanges();
        }

        public IEnumerable<DetailProductViewModel> GetProducts()
        {
            IEnumerable<DetailProductViewModel> products = new List<DetailProductViewModel>();
            products = (from p in vATUShopDbContext.Products
                        join c in vATUShopDbContext.Categories on p.CategoryId equals c.CategoryId
                        join b in vATUShopDbContext.Brands on p.BrandId equals b.BrandId
                        select (new DetailProductViewModel()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            BrandingName = b.BrandName,
                            Price = p.Price,
                            Inventory = p.Inventory,
                            Description = p.Description,
                            ImagePath = p.ImagePath,
                            IsDelete = p.IsDelete
                        }));
            return products;
        }

        public DetailProductViewModel GetProduct(int productId)
        {
            var data = (from p in vATUShopDbContext.Products
                        join c in vATUShopDbContext.Categories
                        on p.CategoryId equals c.CategoryId
                        join b in vATUShopDbContext.Brands
                        on p.BrandId equals b.BrandId
                        where p.ProductId == productId
                        select new DetailProductViewModel()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            CategoryId = c.CategoryId,
                            BrandingName = b.BrandName,
                            BrandingId = b.BrandId,
                            Price = p.Price,
                            Description = p.Description,
                            Inventory = p.Inventory,
                            ImagePath = p.ImagePath
                        }).FirstOrDefault();
            return data;
        }

        public Product ConvertProductViewModel(CreateProductViewModel model)
        {
            string fileName = null;
            if (model.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fs);
                }
            }
            var product = new Product()
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                BrandId = model.BrandingId,
                Price = model.Price,
                Inventory = model.Inventory,
                Description = model.Description,
                ImagePath = fileName
            };
            return product;
        }

        public EditProductViewModel ConvertEditProductViewModel(DetailProductViewModel model)
        {
            var productEdit = new EditProductViewModel()
            {
                ProductName = model.ProductName,
                BrandingId = model.BrandingId,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Inventory = model.Inventory,
                Description = model.Description,
                ImagePath = model.ImagePath
            };
            return productEdit;
        }

        public Product EditProduct(EditProductViewModel model)
        {
            var editProduct = vATUShopDbContext.Products.Find(model.ProductId);
            editProduct.ProductName = model.ProductName;
            editProduct.CategoryId = model.CategoryId;
            editProduct.BrandId = model.BrandingId;
            editProduct.Price = model.Price;
            editProduct.Inventory = model.Inventory;
            editProduct.Description = model.Description;
            editProduct.ImagePath = model.ImagePath;
            string fileName = null;
            if (model.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fs);
                }
                editProduct.ImagePath = fileName;
                if (!string.IsNullOrEmpty(model.ImagePath) && (model.ImagePath != "none-avatar.png"))
                {
                    string delFile = Path.Combine(webHostEnvironment.WebRootPath
                                        , "img", model.ImagePath);
                    System.IO.File.Delete(delFile);
                }
            }
            vATUShopDbContext.SaveChanges();
            return editProduct;
        }

        public bool Delete(int Id)
        {
            var delProduct = vATUShopDbContext.Products.Find(Id);
            if (delProduct != null)
            {
                delProduct.IsDelete = true;
               var result = vATUShopDbContext.SaveChanges() > 0;
                return result;
            }
            return false;
        }
    }
}
