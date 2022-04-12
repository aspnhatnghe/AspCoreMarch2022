using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi09_Validation.Models
{
    public class Employee
    {
        [Display(Name = "Mã định danh")]
        public Guid Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Required]
        [RegularExpression(@"NV\d{5}", ErrorMessage = "Đúng định dạng NVxxxxx")]
        public string EmployeeId { get; set; }

        [Required]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "Email không khớp")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        public bool Gender { get; set; }


        [Display(Name ="Ngày sinh")]
        [CheckBirthDate]
        public DateTime BirthDate { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Lương chưa hợp lệ")]
        public double Salary { get; set; }

        [DataType(DataType.PhoneNumber)]
        public double Phone { get; set; }

        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
