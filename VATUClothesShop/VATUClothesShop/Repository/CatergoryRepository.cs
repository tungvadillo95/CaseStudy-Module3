using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public class CatergoryRepository : ICatergoryRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;
        public CatergoryRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public int CreateCatergory(CatergoryViewModel model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName
            };
            vATUShopDbContext.Categories.Add(category);
            return vATUShopDbContext.SaveChanges();
        }

        public bool DeleteCategory(int Id)
        {
            var delCategory = vATUShopDbContext.Categories.Find(Id);
            if (delCategory != null)
            {
                delCategory.IsDelete = true;
                var result = vATUShopDbContext.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public int EditCatergory(CatergoryViewModel model)
        {
            var editCatergory = vATUShopDbContext.Categories.Find(model.CategoryId);
            editCatergory.CategoryName = model.CategoryName;
            return vATUShopDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return vATUShopDbContext.Categories;
        }

        public CatergoryViewModel GetCatergory(int Id)
        {
            var catergory = (from c in vATUShopDbContext.Categories
                             where c.CategoryId == Id
                             select (new CatergoryViewModel()
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 IsDelete = c.IsDelete
                             })).FirstOrDefault();
            return catergory;
        }
    }
}
