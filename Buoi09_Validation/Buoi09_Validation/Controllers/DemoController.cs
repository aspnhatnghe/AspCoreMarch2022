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
        public IActionResult DemoSync()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            demo.Test01(); demo.Test02(); demo.Test03();
            stopWatch.Stop();
            return Content($"Chạy hết {stopWatch.ElapsedMilliseconds}ms.");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}