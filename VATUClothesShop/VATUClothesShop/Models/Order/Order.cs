using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateShip { get; set; }
        public int AccountCustomerId { get; set; }
        public AccountCustomer AccountCustomer { get; set; }
        public bool Status { get; set; }
        public int PaymentRef { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
