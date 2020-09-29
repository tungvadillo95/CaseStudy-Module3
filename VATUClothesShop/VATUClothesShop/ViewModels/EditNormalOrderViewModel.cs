using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class EditNormalOrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        [DefaultValue(null)]
        public DateTime DateShip { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn trạng thái đơn hàng")]
        public bool Status { get; set; }
        public int PaymentRef { get; set; }
        public bool IsNormalOrder { get; set; }
        public bool IsDelete { get; set; }


        //[MaxLength(200)]
        //public string ProductName { get; set; }
        [Required(ErrorMessage ="Bạn chưa chọn sản phẩm")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên khách hàng")]
        [MaxLength(50)]
        public string NormalOrderCustomerName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại khách hàng")]
        [MaxLength(15)]
        public string NormalOrderPhone { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ khách hàng")]
        [MaxLength(50)]
        public string NormalOrderAddress { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số lượng sản phẩm")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập vào không hợp lệ")]
        public int Quantity { get; set; }
    }
}
