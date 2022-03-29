using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi06_MVCBasic.Models
{
    public class SinhVien
    {
        [Display(Name ="Mã sinh viên")]
        public string MaSv { get; set; }

        [Display(Name = "Họ tên sinh viên")]
        public string HoTen { get; set; }

        [Display(Name = "Điểm trung bình")]
        [Range(0, 10)]
        public double DiemTrungBinh { get; set; }


        public string XepLoai { get; set; }
    }
}
