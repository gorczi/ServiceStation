using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Core.Shop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceStation.Data.Services
{
    public class ShoppingCart
    {
        private readonly AppDbContext _ServiceStationDbContext;

        public string ShoppingCartId { get; set; }

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(AppDbContext ServiceStationDbContext)
        {
            _ServiceStationDbContext = ServiceStationDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                    _ServiceStationDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _ServiceStationDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _ServiceStationDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                    _ServiceStationDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _ServiceStationDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _ServiceStationDbContext.SaveChanges();

            return localAmount;
        }

        public virtual List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _ServiceStationDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _ServiceStationDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _ServiceStationDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _ServiceStationDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _ServiceStationDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
    }
}
