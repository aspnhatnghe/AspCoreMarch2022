using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi07_MVCCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_MVCCore.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult SendFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadSingleFile(IFormFile myfile)
        {
            if (myfile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var pathFile = Path.Combine(path, myfile.FileName);
                using (var newFile = new FileStream(pathFile, FileMode.Create))
                {
                    myfile.CopyTo(newFile);
                }
            }
            return View("SendFile");
        }

        [HttpPost]
        public IActionResult UploadMultipleFile(List<IFormFile> myfiles)
        {
            foreach (var myfile in myfiles)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var pathFile = Path.Combine(path, $"{DateTime.Now.Ticks}_{myfile.FileName}");
                using (var newFile = new FileStream(pathFile, FileMode.Create))
                {
                    myfile.CopyTo(newFile);
                }
            }
            return View("SendFile");
        }
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nhất Nghệ";
            ViewBag.NamThanhLap = new DateTime(2003, 3, 10);

            var hangHoa = new Product
            {
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