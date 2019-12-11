using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        public CartItem()
        {

        }

        public CartItem(Product product, int quantity)
        {
            this.ProductId = product.ProductId;
            this.ProductName = product.ProductName;
            this.Quantity = quantity;
            this.UnitPrice = product.UnitPrice;
        }

        public String TotalPrice()
        {
            double totalPrice = 0;
            totalPrice = this.Quantity * this.UnitPrice;
            return $"{totalPrice:#,##0 đ;($#,##0);Zero}";
        }
    }
}