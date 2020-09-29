using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class DetailProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandingId { get; set; }
        public string BrandingName { get; set; }
        public float Price { get; set; }
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsDelete { get; set; }


        [DefaultValue(0)]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng sản phẩm")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập vào không hợp lệ")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ và tên")]
        [MaxLength(50)]
        [Display(Name ="Họ và tên")]
        public string NormalOrderCustomerName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [RegularExpression(@"(09|03|07[1|2|3|4|5|6|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Display(Name = "Số điện thoại")]
        public string NormalOrderPhone { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ nhận hàng")]
        [MaxLength(50)]
        [Display(Name = "Địa chỉ nhận hàng")]
        public string NormalOrderAddress { get; set; }
    }
}
