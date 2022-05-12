using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_EFCore_DbFirst.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Mã người dùng")]
        [Required]
        public string UserName { get; set; }

        [Display(Name ="Mật khẩu")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
