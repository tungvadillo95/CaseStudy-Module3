using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue(null)]
        public DateTime DateShip { get; set; }
        public string AccountCustomerId { get; set; }
        public ApplicationUser AccountCustomer { get; set; }
        public bool Status { get; set; }
        public int PaymentRef { get; set; }
        public bool IsNormalOrder { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


        public int ProductId { get; set; }
        [MaxLength(50)]
        public string NormalOrderCustomerName { get; set; }
        [MaxLength(15)]
        public string NormalOrderPhone { get; set; }
        [MaxLength(50)]
        public string NormalOrderAddress { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập vào không hợp lệ")]
        public int Quantity { get; set; }
    }
}
