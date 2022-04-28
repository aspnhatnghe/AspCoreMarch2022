using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Buoi17_EFCore_DbFirst.Entities
{
    public partial class VHangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public int MaLoai { get; set; }
        public string MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string MoTa { get; set; }
        public string MaNcc { get; set; }
        public string TenLoai { get; set; }
        public string TenCongTy { get; set; }
        public string DienThoai { get; set; }
    }
}
