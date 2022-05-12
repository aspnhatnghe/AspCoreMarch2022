using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buoi17_EFCore_DbFirst.Entities;
using Buoi17_EFCore_DbFirst.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_EFCore_DbFirst.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;

        public KhachHangController(eStore20Context db)
        {
            _context = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var khachHang = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.UserName && p.MatKhau == model.Password);
            if(khachHang == null)
                return View();

            //tạo cridential claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, khachHang.HoTen),
                new Claim(ClaimTypes.Email, khachHang.Email),
                new Claim("CustomerId", khachHang.MaKh),

                //đọc từ database
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Sales")
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Profile");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}