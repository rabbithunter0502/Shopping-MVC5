using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class ShoppingCart
    {
        private Dictionary<int, CartItem> _items = new Dictionary<int, CartItem>();
        [DataType(DataType.Currency)]
        private double _totalPrice;

        public ShoppingCart()
        {

        }
        public List<CartItem> GetCartItems()
        {
            return _items.Values.ToList();
        }

        public void AddCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_items.ContainsKey(product.ProductId))
            {
                var existItem = _items[product.ProductId];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity += quantity;
                if (existItem.Quantity <= 0)
                {
                    _items.Remove(product.ProductId);
                }
                else
                {
                    _items[product.ProductId] = existItem;
                }
                return;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _items.Add(product.ProductId, new CartItem(product, quantity));
        }
        public void UpdateCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_items.ContainsKey(product.ProductId))
            {
                var existItem = _items[product.ProductId];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity = quantity;
                _items[product.ProductId] = existItem;
                return;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _items.Add(product.ProductId, new CartItem(product, quantity));
        }

        public void RemoveCartItem(int productId)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_items.ContainsKey(productId))
            {
                _items.Remove(productId);
                return;
            }
        }
        public double GetTotalPrice()
        {
            this._totalPrice = 0;
            foreach (var cartItem in _items.Values.ToList())
            {
                this._totalPrice += cartItem.UnitPrice * cartItem.Quantity;
            }
            return this._totalPrice;
        }
        public String GetTotalPriceString()
        {
            this._totalPrice = 0;
            foreach (var cartItem in _items.Values.ToList())
            {
                this._totalPrice += cartItem.UnitPrice * cartItem.Quantity;
            }
            return $"{this._totalPrice:#,##0 đ;($#,##0);Zero}";
        }
    }
}