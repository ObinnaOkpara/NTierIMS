using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierIMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTierIMS.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseInventoryItem> WarehouseInventoryItems { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Removal> Removals { get; set; }

    }
}
