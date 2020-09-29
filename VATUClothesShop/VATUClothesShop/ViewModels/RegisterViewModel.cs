using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận lại mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [Display(Name = "Điện thoại")]
        [RegularExpression(@"(09|03|07[1|2|3|4|5|6|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
