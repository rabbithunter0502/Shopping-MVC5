using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.Service;

namespace Shopping.Controllers
{
    public class ShoppingCartController : Controller
    {
        MyDbContext db = new MyDbContext();
        private IOderService orderService = new OrderService();
        public static string ShoppingCartAttribute = "ShoppingCart";

        // GET: ShoppingCart
        public ActionResult Cart()
        {
            ViewBag.ShoppingCart = LoadShoppingCart();
            return View();
        }

        public ActionResult CheckOut()
        {
            var shoppingCart = LoadShoppingCart();
            return View();
        }
        public ActionResult CreateOrder(CartInformation cartInformation)
        {
            var shoppingCart = LoadShoppingCart();
            if (orderService.CreateOrder(shoppingCart, cartInformation))
            {
                TempData["msg"] = "Order success!";
                ClearCart();
            }
            return Redirect("/ShoppingCart/Cart");
        }
        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }

            var shoppingCart = LoadShoppingCart();
            shoppingCart.AddCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            //return Request.IsAjaxRequest() ? (ActionResult)PartialView("_CartPartial") : Redirect("/Products/ShowProduct");
            return Redirect("/ShoppingCart/Cart");

        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid quantity.'");
            }
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.UpdateCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.RemoveCartItem(productId);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        private void ClearCart()
        {
            Session.Remove(ShoppingCartAttribute);
        }

        /**
         * Lưu thông tin cart vào session.
         */
        public void SaveShoppingCart(Models.ShoppingCart shoppingCart)
        {
            Session[ShoppingCartAttribute] = shoppingCart;
        }

        public Models.ShoppingCart LoadShoppingCart()
        {
            if (Session[ShoppingCartAttribute] is Models.ShoppingCart currentShoppingCart)
            {
                return currentShoppingCart;
            }
            return new Models.ShoppingCart();
        }
    }
}