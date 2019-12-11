using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        public double OldPrice { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; }
        public enum ProductStatus
        {
            OverSell = 1,
            NotCurrent = 2,
            Current = 3,
        }

        public virtual Category Category { get; set; }
    }
}