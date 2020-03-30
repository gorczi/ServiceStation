using Microsoft.EntityFrameworkCore;
using ServiceStation.Models;

namespace ServiceStation.Services
{
    public class ServiceStationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ServiceStationDbContext(DbContextOptions<ServiceStationDbContext> options)
            : base(options)
        {

        }
    }
}
