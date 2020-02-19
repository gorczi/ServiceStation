using ServiceStation.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Core.Services
{
    public class MockProductRepository : IProductRepository
    {
        List<Product> products;
        public MockProductRepository()
        {
            products = new List<Product>()
            {
                new Product { Id = 0, Name = "Scale 520", Category = Category.Bike, Manufacturer = "Scott", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis. Donec ac ipsum sit amet leo blandit tincidunt non nec mi. Ut pulvinar consequat ex at efficitur. Vestibulum tempor dui a tempus varius. Phasellus at turpis imperdiet, tempor mauris id, hendrerit libero. Nunc eu eros maximus, commodo ante nec, rhoncus augue. Quisque vestibulum rutrum orci a venenatis. Fusce auctor at nunc sed condimentum. ", Price = 999 },
                new Product { Id = 0, Name = "Mule 910", Category = Category.Accessory, Manufacturer = "Brott", Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis. Donec ac ipsum sit amet leo blandit tincidunt non nec mi. Ut pulvinar consequat ex at efficitur. Vestibulum tempor dui a tempus varius. Phasellus at turpis imperdiet, tempor mauris id, hendrerit libero. Nunc eu eros maximus, commodo ante nec, rhoncus augue. Quisque vestibulum rutrum orci a venenatis. Fusce auctor at nunc sed condimentum. ", Price = 1300},
                new Product { Id = 0, Name = "2000", Category = Category.Part, Manufacturer = "Nimbus", Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet condimentum nisi. Praesent a egestas ex, non sodales turpis. Donec ac ipsum sit amet leo blandit tincidunt non nec mi. Ut pulvinar consequat ex at efficitur. Vestibulum tempor dui a tempus varius. Phasellus at turpis imperdiet, tempor mauris id, hendrerit libero. Nunc eu eros maximus, commodo ante nec, rhoncus augue. Quisque vestibulum rutrum orci a venenatis. Fusce auctor at nunc sed condimentum. ", Price = 4000}
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
