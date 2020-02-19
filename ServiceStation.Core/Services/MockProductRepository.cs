using ServiceStation.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Core.Services
{
    public class MockProductRepository : IProductData
    {
        List<Product> products;
        public MockProductRepository()
        {
            products = new List<Product>()
            {
                new Product { Id = 0, Name = "Scale 520", Category = Category.Bike, Manufacturer = "Scott", Description = "Best bike to ride", Price = 999 },
                new Product { Id = 0, Name = "Scale 520", Category = Category.Bike, Manufacturer = "Scott", Description= "Best bike to ride", Price = 999},
                new Product { Id = 0, Name = "Scale 520", Category = Category.Bike, Manufacturer = "Scott", Description= "Best bike to ride", Price = 999}
            };
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products.OrderBy(r => r.Name);
        }
    }
}
