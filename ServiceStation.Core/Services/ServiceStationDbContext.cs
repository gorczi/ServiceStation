using Microsoft.EntityFrameworkCore;
using ServiceStation.Core.Domain;
using ServiceStation.Core.Domain.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Core.Services
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
