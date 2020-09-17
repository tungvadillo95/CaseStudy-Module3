using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Models.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        int CreateProduct(Product product);
        IEnumerable<Product> GetProducts();
        DetailProductViewModel Get(int productId);
    }
}

