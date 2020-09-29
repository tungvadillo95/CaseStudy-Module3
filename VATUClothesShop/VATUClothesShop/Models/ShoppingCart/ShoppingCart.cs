using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        [ForeignKey("AspNetUsers")]
        public string AccountCustomerId { get; set; }
        public ApplicationUser AccountCustomer { get; set; }
        public bool IsDelete { get; set; }
    }
}
