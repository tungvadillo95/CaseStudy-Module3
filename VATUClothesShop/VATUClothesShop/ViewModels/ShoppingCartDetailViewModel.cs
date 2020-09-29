using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class ShoppingCartDetailViewModel
    {
        public int ShoppingCartDetailId { get; set; }
        public int ShoppingCartId { get; set; }
        public string AccountCustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public bool IsDelete { get; set; }
    }
}
