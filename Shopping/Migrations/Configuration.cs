using System.Collections.Generic;
using Shopping.Models;

namespace Shopping.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shopping.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shopping.Models.MyDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
            List<Product> lsProducts = new List<Product>();
            lsProducts.Add(new Product()
            {
                ProductName = "",
                ProductId = 1,
                CategoryId = 1,
                Image = "",
                Quantity = 100,
                Status = 1,
                UnitPrice = 100,
                OldPrice = 100,
                CreatedAt = 0,
                UpdatedAt = 0,
                DeletedAt = 0,
            });
            context.Products.AddRange(lsProducts);
            context.SaveChanges();

        }
    }
}
