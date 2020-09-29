using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public interface IOderRepository
    {
        IEnumerable<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int orderId);
        bool Delete(int Id);
        EditNormalOrderViewModel ConvertEditNormalOrderViewModel(OrderViewModel model);
        int EditNormalOrder(OrderViewModel model);
    }
}
