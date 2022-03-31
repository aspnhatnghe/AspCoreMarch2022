using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07_MVCCore.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //public double Total
        //{
        //    get { return Price * Quantity; }
        //}
        public double Total => Price * Quantity;
    }
}
