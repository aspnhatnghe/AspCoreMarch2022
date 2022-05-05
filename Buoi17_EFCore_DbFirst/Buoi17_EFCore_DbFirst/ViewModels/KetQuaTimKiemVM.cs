using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_EFCore_DbFirst.ViewModels
{
    public class KetQuaTimKiemVM
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public double DonGia { get; set; }
        public DateTime NgaySX { get; set; }
        public string Loai { get; set; }
    }
}
