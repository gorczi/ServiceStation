using Microsoft.EntityFrameworkCore;
using ServiceStation.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStation.Core.Services
{
    public class ServiceStationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
