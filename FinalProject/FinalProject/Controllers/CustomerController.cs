using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopDbContext _context;

        public CustomerController(ShopDbContext ctx)
        {
            _context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}