using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderDetail()
        {

        }

        public OrderDetail(CartItem item, int orderId)
        {
            this.ProductId = item.ProductId;
            this.ProductName = item.ProductName;
            this.OrderId = orderId;
            this.UnitPrice = item.UnitPrice;
        }

    }
}