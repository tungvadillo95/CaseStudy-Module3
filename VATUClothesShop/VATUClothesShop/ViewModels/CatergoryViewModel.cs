using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class CatergoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Bạn chưa nhập tên loại hàng")]
        [MaxLength(100)]
        [Display(Name ="Tên loại hàng")]
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
    }
}
