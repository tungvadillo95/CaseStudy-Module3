using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(200)]
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Inventory { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
