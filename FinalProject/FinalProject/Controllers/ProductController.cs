using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.Data;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            var data = _mapper.Map<List<ProductVM>>(products.ToList());

            return View(data);
        }
    }
}