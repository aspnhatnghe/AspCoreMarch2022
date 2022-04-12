using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buoi09_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi09_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult DangKy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string FullName, int Age)
        {
            return View();
        }

        public IActionResult CheckValidEmployeeId(string EmployeeId)
        {
            var empInDatabase = new List<string>()
            {
                "admin", "guest", "nhatnghe", "aspnet", "NV77777"
            };
            if (empInDatabase.Contains(EmployeeId))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                //thông báo lỗi do người dùng định nghĩa
                ModelState.AddModelError("AAA", "Thành công");
            }
            else
            {
                ModelState.AddModelError("AAA", "Thất bại");
            }
            return View();
        }

        public async Task<IActionResult> DemoAsyncRun()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var test1 = demo.Test01Async();
            var test2 = demo.Test02Async();
            var test3 = demo.Test03Async();
            await test1; await test2; await test3;
            stopWatch.Stop();
            return Content($"Chạy hết {stopWatch.ElapsedMilliseconds}ms.");
        }

        public IActionResult DemoSync()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            demo.Test01(); demo.Test02(); demo.Test03();
            stopWatch.Stop();
            return Content($"Chạy hết {stopWatch.ElapsedMilliseconds}ms.");
        }

        public IActionResult DemoRazor()
        {
            return View();
        }
    }
}