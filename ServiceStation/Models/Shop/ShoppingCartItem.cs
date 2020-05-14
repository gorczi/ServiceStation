namespace ServiceStation.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
