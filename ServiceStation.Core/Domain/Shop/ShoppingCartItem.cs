using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Core.Domain.Shop
{
    class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
