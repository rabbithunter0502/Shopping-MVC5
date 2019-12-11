using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.Entity;

namespace Shopping.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DefaultConnection")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}