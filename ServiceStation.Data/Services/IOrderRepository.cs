using ServiceStation.Core.Shop;
using System.Collections.Generic;

namespace ServiceStation.Data.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        public IEnumerable<Order> GetOrders(string userId);
    }
}
 