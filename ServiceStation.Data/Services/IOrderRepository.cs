using ServiceStation.Core.Shop;

namespace ServiceStation.Data.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
 