using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_EFCore_DbFirst.Entities;
using Buoi17_EFCore_DbFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_EFCore_DbFirst.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }


        #region Simple Search
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var dsHangHoa = _context.HangHoa.Where(p => p.TenHh.Contains(keyword));

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return PartialView("TimKiemPartial", data);
        }

        #endregion

        public AjaxController(eStore20Context context)
        {
            _context = context;
        }

        #region Tìm kiếm - trả về JSON
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleSearch(string keyword, double? from, double? to)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.TenHh.Contains(keyword));
            }
            if (from.HasValue)
            {
                data = data.Where(p => p.DonGia.Value >= from);
            }
            if (to.HasValue)
            {
                data = data.Where(p => p.DonGia.Value <= to);
            }
            var result = data.Select(p => new { 
                HangHoa = p.TenHh,
                GiaBan = p.DonGia.Value,
                Loai = p.MaLoaiNavigation.TenLoai
            });
            return Json(result);
        }
        #endregion
    }
}