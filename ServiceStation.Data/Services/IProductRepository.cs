using ServiceStation.Core.Shop;
using System.Collections.Generic;
using System.Linq;

namespace ServiceStation.Data.Services
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
