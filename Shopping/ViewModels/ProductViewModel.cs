using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.ViewModels
{
    public class ProductViewModel
    {
        private MyDbContext db = new MyDbContext();
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double UnitPrice { get; set; }
        public double OldPrice { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }

        public ProductViewModel()
        {

        }
        public ProductViewModel(Models.Product product)
        {
            if (db.Products.Find(product.ProductId) != null)
            {
                this.ProductId = product.ProductId;
                this.ProductName = product.ProductName;
                this.Image = product.Image;
                this.UnitPrice = product.UnitPrice;
                this.OldPrice = product.OldPrice;
                this.CategoryId = product.CategoryId;
                this.Quantity = product.Quantity;
                this.CategoryName = GetCategoryName();
            }
        }

        public string GetCategoryName()
        {
            if (CategoryId > 0)
            {
                return this.CategoryName = db.Categories.Find(this.CategoryId)?.CategoryName;
            }

            return "Invalid";
        }
    }
}