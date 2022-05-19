using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStoreAPI.Models
{
    public class LoginVM
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
