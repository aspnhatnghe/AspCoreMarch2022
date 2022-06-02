using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class LoginVM
    {
        [MaxLength(30)]
        [Required]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}
