using ServiceStation.Core.Shop;
using System.Collections.Generic;
using System.Linq;

namespace ServiceStation.Data.Services
{
    public class MockProductRepository : IProductRepository
    {
        List<Product> products;

        public MockProductRepository()
        {
            products = new List<Product>()
            {
                new Product { Id = 0, Name = "Scale 520", Category = Category.Bike, Manufacturer = "Scott", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis.", Price = 999 },
                new Product { Id = 1, Name = "Mule 910", Category = Category.Accessory, Manufacturer = "Brott", Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis.", Price = 1300},
                new Product { Id = 2, Name = "2000", Category = Category.Part, Manufacturer = "Nimbus", Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis.", Price = 4000}
            };
        }

        public Product Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return product;
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(r => r.Id == id);
        }

        public Product Update(Product product)
        {
            var existing = products.SingleOrDefault(p=> p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Manufacturer = product.Manufacturer;
                existing.Description = product.Description;
                existing.Category = product.Category;
                existing.Price = product.Price;
            }
            return existing;
        }

        public IEnumerable<Product> GetAll()
        {
            return products.OrderBy(r => r.Name);
        }

        public Product Delete(int id)
        {
            var product = products.FirstOrDefault(r => r.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return null;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
