using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;

namespace VATUClothesShop.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Products = new List<DetailProductViewModel>();
        }
        public IEnumerable<DetailProductViewModel> Products { get; set; }
        [Display(Name ="Mã đơn hàng")]
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Ngày tạo đơn hàng")]
        public DateTime DateCreated { get; set; }
        [DefaultValue(null)]
        public DateTime DateShip { get; set; }
        public string AccountCustomerId { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public int PaymentRef { get; set; }
        public bool IsNormalOrder { get; set; }
        public bool IsDelete { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa chọn sản phẩm")]
        public int ProductId { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên khách hàng")]
        [MaxLength(50)]
        public string NormalOrderCustomerName { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại khách hàng")]
        [MaxLength(15)]
        public string NormalOrderPhone { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ khách hàng")]
        [MaxLength(50)]
        public string NormalOrderAddress { get; set; }
        [Display(Name = "Số lượng sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng sản phẩm")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập vào không hợp lệ")]
        public int Quantity { get; set; }
    }
}
