using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class CartInformation
    {
        public int PaymentTypeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public enum PaymentName
        {
            Cod = 1,
            InternetBanking = 2,
            DirectTransfer = 3
        }
    }
}