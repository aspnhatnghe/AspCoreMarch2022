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
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }

    [Table("OrderDetail")]
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product{ get; set; }
        [ForeignKey("ColorId")]
        public BrandColor Color { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
    }
}