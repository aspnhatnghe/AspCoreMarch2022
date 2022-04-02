using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07_MVCCore.Models
{
    public class StudentInfo
    {
        [Display(Name = "Mã sinh viên")]
        [Required(ErrorMessage = "*")]
        public string StudentId { get; set; }

        [Display(Name = "Họ tên sinh viên")]
        [Required(ErrorMessage = "*")]
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        public string FullName { get; set; }

        [Display(Name = "Điểm trung bình")]
        [Range(0, 10, ErrorMessage = "Điểm từ 0 --> 10")]
        public double Grade { get; set; }

        [Display(Name = "Xếp loại")]
        public string Rating
        {
            get
            {
                if (Grade < 5)
                {
                    return "Kém";
                }
                else if (Grade < 7)
                {
                    return "Trung bình";
                }
                else if (Grade < 8.5)
                {
                    return "Khá";
                }
                else
                {
                    return "Giỏi";
                }
            }
        }
    }
}
