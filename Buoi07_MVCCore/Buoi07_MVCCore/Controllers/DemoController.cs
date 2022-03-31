using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi07_MVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_MVCCore.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nhất Nghệ";
            ViewBag.NamThanhLap = new DateTime(2003, 3, 10);

            var hangHoa = new Product { 
                Id = Guid.NewGuid(),
                ProductName = "Bia Sài Gòn",
                Price = 14500,
                Quantity = 24
            };
            ViewBag.HangHoa = hangHoa;
            //TempData["hanghoa"] = hangHoa;
            TempData["Demo"] = 12345;
            //return View();

            //return RedirectToAction("Process");
            //return RedirectToAction("Process", "Demo");
            //return Redirect("/Demo/Process");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Process()
        {
            return View("Index");
        }
    }
}