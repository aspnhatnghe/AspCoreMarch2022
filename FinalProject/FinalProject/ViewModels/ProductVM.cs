using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class ProductVM
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
