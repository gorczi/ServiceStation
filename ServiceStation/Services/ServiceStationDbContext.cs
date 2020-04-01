using Microsoft.EntityFrameworkCore;
using ServiceStation.Models;

namespace ServiceStation.Services
{
    public class ServiceStationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ServiceStationDbContext(DbContextOptions<ServiceStationDbContext> options)
            : base(options)
        {

        }
    }
}
