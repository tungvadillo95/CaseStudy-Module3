using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.ViewModels
{
    public class UserCreateViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Vai trò")]
        public string RolesId { get; set; }
    }
}
