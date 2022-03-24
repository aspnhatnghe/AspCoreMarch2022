using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi03_CSS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi03_CSS.Controllers
{
    public class HangHoaController : Controller
    {
        public IActionResult Index()
        {
            //B1: Lấy danh sách hàng hóa
            var random = new Random();
            var soLuong = random.Next(5, 100);
            var danhSachHangHoa = new List<HangHoa>()
            {
                //new HangHoa
                //{
                //    TenHangHoa = "IPhone 13",
                //    Hinh = "",
                //    DonGia = 20990900,
                //    HangMoi = false
                //},
                //new HangHoa
                //{
                //    TenHangHoa = "IPhone 14",
                //    Hinh = "",
                //    DonGia = 22990900,
                //    HangMoi = true
                //},
            };
            for (var i = 0; i < soLuong; i++)
            {
                danhSachHangHoa.Add(new HangHoa
                {
                    TenHangHoa = "IPhone " + random.Next(6, 21),
                    Hinh = "",
                    DonGia = random.NextDouble() * 10000000,
                    HangMoi = random.Next() % 2 == 0
                });
            }

            //B2: Chuyển dữ liệu danh sách qua View để hiển thị (gửi qua Model)
            return View(danhSachHangHoa);
            //return View("DanhSach", danhSachHangHoa);
        }
    }
}