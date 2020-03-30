using ServiceStation.Models;
using System.Collections.Generic;

namespace ServiceStation.Services
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
