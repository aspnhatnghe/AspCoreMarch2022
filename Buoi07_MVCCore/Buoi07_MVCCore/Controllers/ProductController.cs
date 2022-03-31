using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi07_MVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_MVCCore.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia 333",
                Price = 15900,
                Quantity =23
            },
            new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Bia Heineiken",
                Price = 19500,
                Quantity =29
            }
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //LINQ, lambda
            var product = Products.SingleOrDefault(item => item.Id == id);

            if (product == null)//không có
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Product model)
        {
            var product = Products.SingleOrDefault(item => item.Id == id);
            if (product != null)//có
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Quantity = model.Quantity;

                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}