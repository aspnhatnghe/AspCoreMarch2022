using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_EFCore_DbFirst.ViewModels
{
    public class LoaiVM
    {
        [Display(Name ="Mã loại")]
        public int MaLoai { get; set; }
        [Display(Name ="Tên loại")]
        [MaxLength(50)]
        public string TenLoai { get; set; }
        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
    }
}
