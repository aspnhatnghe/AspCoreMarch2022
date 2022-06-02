using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public enum OrderStatus
    {
        New = 0,
        Confirm = 1,
        Payment = 2,
        Delivery = 3,
        Cancel = -1
    }

    [Table("Order")]
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalPrice { get; set; }
    }
}
