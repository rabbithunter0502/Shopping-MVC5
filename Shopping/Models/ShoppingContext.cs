using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class ShoppingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ShoppingContext() : base("name=ShoppingContext")
        {
        }

        public System.Data.Entity.DbSet<Shopping.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Shopping.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Shopping.Models.Order> Orders { get; set; }
    }
}
