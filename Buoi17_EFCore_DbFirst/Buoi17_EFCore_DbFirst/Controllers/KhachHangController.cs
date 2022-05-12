using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi17_EFCore_DbFirst.Entities;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}