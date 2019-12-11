using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Shopping.Models;
using Shopping.ViewModels;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index(string currentFilter, string searchString)
        {
            

            ViewBag.CurrentFilter = searchString;
            var products = db.Products.Include(p => p.Category);
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }
            List<ProductViewModel> lsProductViewMode = new List<ProductViewModel>();
            var lsProducts = db.Products.ToList();
            foreach (var item in lsProducts)
            {
                ProductViewModel productViewModel = new ProductViewModel(item);
                lsProductViewMode.Add(productViewModel);
            }
           
            return View(lsProductViewMode.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}