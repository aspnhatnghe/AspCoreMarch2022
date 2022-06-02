using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.Data;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ShopDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public IActionResult Index(int? id)
        {
            var products = _context.Products.AsQueryable();
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id);
            }

            var data = products.Select(p => new ProductVM { 
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Image = p.Image,
                SoldPrice = p.ProductPrices.FirstOrDefault().Price
            }).ToList();

            //var data = _mapper.Map<List<ProductVM>>(products.ToList());
            //foreach(var item in data)
            //{
            //    var p_price = _context.ProductPrices.FirstOrDefault(c => c.ProductId == item.ProductId);
            //    if(p_price != null)
            //    {
            //        item.SoldPrice = p_price.Price;
            //    }
            //}

            return View(data);
        }

        public IActionResult Detail(Guid id)
        {
            var prod = _context.Products
                .Include(p => p.ProductPrices)
                .ThenInclude(pp => pp.Size)
                .SingleOrDefault(p => p.ProductId == id);
            if(prod == null)
            {
                return NotFound();
                //return Redirect("/NotFound");
            }

            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Sizes = _context.Sizes.ToList();
            return View(prod);
        }
    }
}