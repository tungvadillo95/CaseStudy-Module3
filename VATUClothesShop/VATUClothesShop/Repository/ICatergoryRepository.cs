using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public interface ICatergoryRepository
    {
        IEnumerable<Category> GetCategories();
        CatergoryViewModel GetCatergory(int Id);
        int CreateCatergory(CatergoryViewModel model);
        int EditCatergory(CatergoryViewModel model);
        bool DeleteCategory(int Id);
    }
}
