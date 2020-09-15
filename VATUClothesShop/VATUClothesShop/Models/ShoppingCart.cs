using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        public int CustomerId { get; set; }
    }
}
