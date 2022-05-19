using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EStoreAPI.Data
{
    public partial class VHoaDon
    {
        public int MaCt { get; set; }
        public int MaHd { get; set; }
        public int MaHh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public string MaKh { get; set; }
        public DateTime NgayDat { get; set; }
        public string TenHh { get; set; }
        public string TenLoai { get; set; }
    }
}
