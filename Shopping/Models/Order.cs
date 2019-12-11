using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public double TotalPrice { get; set; }
        public long CreateAt { get; set; }
        public long UpdateAt { get; set; }
        public long DeleteAt { get; set; }
        public int Status { get; set; }

        public enum OrderStatus
        {
            Pending = 5,
            Confirmed = 4,
            Shipping = 3,
            Paid = 2,
            Done = 1,
            Cancel = 0,
            Deleted = -1
        }
        public enum PaymentTypeName
        {
            Cod = 1,
            InternetBanking = 2,
            DirectTransfer = 3
        }
        public Order()
        {
            CreateAt = DateTime.Now.Ticks;
            UpdateAt = DateTime.Now.Ticks;
            Status = (int)Order.OrderStatus.Pending;
        }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}