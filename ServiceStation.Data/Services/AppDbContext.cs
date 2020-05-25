using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Core.Auth;
using ServiceStation.Core.Shop;

namespace ServiceStation.Data.Services
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<AddressData> Addresses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
