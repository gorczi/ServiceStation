using ServiceStation.Core.Shop;
using System.Collections.Generic;

namespace ServiceStation.Data.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        Order GetOrder(int orderId);
        //TODO refactor GetOrders =>GetOrdersByUser
        IEnumerable<Order> GetOrders(string userId);
        
    }
}
 