using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.Data;
using FinalProject.Utils;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ShopDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<Customer>(model);
                    customer.IsActive = true;//false ==> link/mail ==> change active true
                    customer.RandomKey = MyTool.GetRandom();
                    customer.Password = model.Password.ToSHA512Hash(customer.RandomKey);

                    _context.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.UserName == model.UserName);

                if (customer == null)
                {
                    ModelState.AddModelError("loi", "User này không có");
                    return View();
                }
                if (!customer.IsActive)
                {
                    ModelState.AddModelError("loi", "User này chưa kích hoạt sử dụng");
                    return View();
                }
                if(customer.Password != model.Password.ToSHA512Hash(customer.RandomKey))
                {
                    ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                    return View();
                }
            }
            return View();
        }
    }
}