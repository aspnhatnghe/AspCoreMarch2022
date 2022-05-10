using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_EFCore_DbFirst.Entities;
using Buoi17_EFCore_DbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_EFCore_DbFirst.Controllers
{
    public class CartController : Controller
    {
        public CartController(eStore20Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(Carts);
        }

        const string MY_CART_KEY = "GioHang";
        private readonly eStore20Context _context;

        public List<CartItem> Carts
        {
            get
            {
                var gioHang = HttpContext.Session.Get<List<CartItem>>(MY_CART_KEY);
                if (gioHang == null)
                {
                    gioHang = new List<CartItem>();
                }
                return gioHang;
            }
        }

        public IActionResult AddToCart(int id, int qty = 1)
        {
            var gioHang = Carts;

            //kiểm tra xem mã hàng hóa đã có trong giỏ hay chưa
            var item = gioHang.SingleOrDefault(hh => hh.MaHh == id);
            if (item != null)//có rùi nè
            {
                item.SoLuong += qty;
            }
            else
            {
                var hangHoa = _context.HangHoa.SingleOrDefault(p => p.MaHh == id);
                if (hangHoa == null) return NotFound();

                item = new CartItem
                {
                    MaHh = id,
                    SoLuong = qty,
                    TenHh = hangHoa.TenHh,
                    DonGia = hangHoa.DonGia.Value,
                    Hinh = hangHoa.Hinh
                };
                gioHang.Add(item);
            }

            HttpContext.Session.Set(MY_CART_KEY, gioHang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Carts;
            var item = gioHang.SingleOrDefault(hh => hh.MaHh == id);
            if(item != null)
            {
                gioHang.Remove(item);
            }
            HttpContext.Session.Set(MY_CART_KEY, gioHang);

            return RedirectToAction("Index");
        }
    }
}