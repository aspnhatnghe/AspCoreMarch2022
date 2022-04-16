using Buoi09_Validation.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi09_Validation.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategory _category;

        public CategoryMenu(ICategory category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {            
            return View(_category.GetAll());
        }
    }
}
