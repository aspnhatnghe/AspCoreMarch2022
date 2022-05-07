using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_EFCore_DbFirst.Entities;
using Buoi17_EFCore_DbFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_EFCore_DbFirst.Controllers
{
    public class DemoController : Controller
    {
        private readonly eStore20Context _context;

        public DemoController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult ThongKe()
        {
            var data = _context.ChiTietHd
                .GroupBy(cthd => cthd.MaHhNavigation.MaLoaiNavigation.TenLoai)
                .Select(cthdg => new ThongkeVM
                {
                    Loai = cthdg.Key,
                    DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia)),
                    SoHH = cthdg.Count(),
                    GiaTB = cthdg.Average(s => s.DonGia)
                });
            //return Json(data);
            return View(data.ToList());
        }

        public IActionResult ThongKeKhachHang()
        {
            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    cthd.MaHdNavigation.MaKh,
                    cthd.MaHdNavigation.MaKhNavigation.HoTen,
                    cthd.MaHdNavigation.MaKhNavigation.DienThoai
                })
                .Select(cthdg => new
                {
                    MaKh = cthdg.Key.MaKh,
                    HoTenKhachHang = cthdg.Key.HoTen,
                    SoDT = cthdg.Key.DienThoai,
                    DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia))
                });
            return Json(data);
        }

        public IActionResult ThongKeLoaiTheoNam()
        {
            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
                    cthd.MaHdNavigation.NgayDat.Year
                })
                .Select(cthdg => new
                {
                    Loai = cthdg.Key.TenLoai,
                    Nam = cthdg.Key.Year,
                    DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia))
                });
            return Json(data);
        }

        /// <summary>
        /// Hàm phân trang + tìm kiếm
        /// </summary>
        /// <param name="search">từ khóa cần tìm</param>
        /// <param name="p">trang thứ</param>
        /// <returns></returns>
        public IActionResult Index(string search, int p = 1, string sortBy = "DonGia", bool ascSort = true)
        {
            var dsHangHoa = _context.HangHoa.AsQueryable();

            //Filter
            if (!string.IsNullOrEmpty(search))
            {
                dsHangHoa = dsHangHoa.Where(p => p.TenHh.Contains(search));
            }

            //Sort
            switch (sortBy)
            {
                case "DonGia": dsHangHoa = ascSort ? dsHangHoa.OrderBy(p => p.DonGia) : dsHangHoa.OrderByDescending(p => p.DonGia); break;
                case "TenHh": dsHangHoa = ascSort ? dsHangHoa.OrderBy(p => p.TenHh) : dsHangHoa.OrderByDescending(p => p.TenHh); break;
            }
            ViewBag.SortBy = sortBy;
            ViewBag.AscSort = ascSort;

            //Paging
            const int SoPhanTuMoiTrang = 9;
            ViewBag.TrangHienTai = p;
            ViewBag.TongSoTrang = Math.Ceiling(1.0 * dsHangHoa.Count() / SoPhanTuMoiTrang);

            dsHangHoa = dsHangHoa.Skip((p - 1) * SoPhanTuMoiTrang).Take(SoPhanTuMoiTrang);

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return View(data);
        }
    }
}