using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Services
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
 