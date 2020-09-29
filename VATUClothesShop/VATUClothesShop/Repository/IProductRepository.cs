using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public interface IProductRepository
    {
        int CreateProduct(Product product);
        IEnumerable<DetailProductViewModel> GetProducts();
        DetailProductViewModel GetProduct(int productId);
        Product ConvertProductViewModel(CreateProductViewModel model);
        EditProductViewModel ConvertEditProductViewModel(DetailProductViewModel model);
        Product EditProduct(EditProductViewModel model);
        bool Delete(int Id);
    }
}

