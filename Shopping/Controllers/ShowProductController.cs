using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.ViewModels;

namespace Shopping.Controllers
{
    public class ShowProductController : Controller
    {
        MyDbContext db = new MyDbContext();
        
        // GET: ShowProduct
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult SingleProduct(int? productId)
        {
            if (productId == null)
            {
                return View("Products");
            }
            var product = db.Products.Find(productId);
            var productView = new ProductViewModel(product);
            return View(productView);
        }
    }
}