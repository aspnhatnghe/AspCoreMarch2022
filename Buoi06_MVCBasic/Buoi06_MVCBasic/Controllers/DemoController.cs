using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi06_MVCBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06_MVCBasic.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Manage(SinhVien model)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        // /Demo/Hello  //routing default
        // /Demo/Hello?ten=Nhất Nghệ //routing default

        [HttpGet("Chao")]
        [HttpGet("/Hello")]
        [HttpGet("/SayHello/{ten}")]
        public string Hello(string ten)
        {
            return $"Hello {ten}.";
        }

        //Demo friendly URL/SEO
        [HttpGet("/{loai}/{hangHoa}")]
        public string LayHangHoa(string loai, string hangHoa)
        {
            return $"Loại: {loai}/hàng hóa: {hangHoa}";
        }
    }
}