using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi15_ADONET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi15_ADONET.Controllers
{
    public class LoaiController : Controller
    {
        public IActionResult Index()
        {
            return View(LoaiDataAccessLayer.GetAll());
        }

        public IActionResult Edit(int id)
        {
            var loai = LoaiDataAccessLayer.GetById(id);
            if (loai != null)
            {
                return View(loai);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            var newLoai = LoaiDataAccessLayer.Add(loai);
            if (newLoai == null)
            {
                return View();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("Edit", new { id = newLoai.MaLoai });
        }
    }
}