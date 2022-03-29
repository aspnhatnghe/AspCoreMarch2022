using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06_MVCBasic.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double SoHang1, double SoHang2, string PhepToan)
        {
            //return Content($"{SoHang1} {PhepToan} {SoHang2}");
            ViewBag.SoHang1 = SoHang1;
            ViewData["SoHang2"] = SoHang2;
            ViewBag.PhepToan = PhepToan;

            var ketQua = string.Empty;
            switch (PhepToan)
            {
                case "+": ketQua = (SoHang1 + SoHang2).ToString(); break;
                case "-": ketQua = (SoHang1 - SoHang2).ToString(); break;
                case "*": ketQua = (SoHang1 * SoHang2).ToString(); break;
                case "/": ketQua = (SoHang1 / SoHang2).ToString(); break;
                case "%": ketQua = (SoHang1 % SoHang2).ToString(); break;
                case "^": ketQua = Math.Pow(SoHang1, SoHang2).ToString(); break;
            }
            ViewBag.KetQua = ketQua;
            //return View("Index");
            return View("~/Views/Calculator/Index.cshtml");
        }
    }
}