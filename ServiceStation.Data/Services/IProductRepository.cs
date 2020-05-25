using ServiceStation.Core.Shop;
using System.Collections.Generic;

namespace ServiceStation.Data.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
