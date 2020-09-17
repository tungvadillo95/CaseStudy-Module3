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
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandingName { get; set; }
        public float Price { get; set; }
        [DefaultValue(0)]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập vào không đúng")]
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
