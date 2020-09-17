using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class AccountCustomer : IdentityUser
    {
        [DefaultValue(0)]
        public int VipLevel { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
