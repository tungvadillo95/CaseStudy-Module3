using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Models
{
    public class CartProduct
    {
        public DetailProductViewModel Product { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm không hoepj lệ")]
        public int Quantity { get; set; }

    }
}
