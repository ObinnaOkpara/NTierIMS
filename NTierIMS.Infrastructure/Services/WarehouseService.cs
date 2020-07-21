using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;
using NTierIMS.Infrastructure.Contexts;

namespace NTierIMS.Infrastructure.Services
{
    public class WarehouseService : IWarehouseService
    {
        protected readonly ApplicationDbContext _dbContext;

        public WarehouseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Warehouse> AddAsync(Warehouse warehouse)
        {
            await _dbContext.Warehouses.AddAsync(warehouse);
            await _dbContext.SaveChangesAsync();

            return warehouse;
        }

        public async Task DeleteAsync(Warehouse warehouse)
        {
            _dbContext.Warehouses.Remove(warehouse);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _dbContext.Warehouses.Include(m => m.Employee).Include(m => m.WarehouseInventoryItems)
                .ThenInclude(n => n.InventoryItem).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Warehouse>> ListAllAsync()
        {
            return await _dbContext.Warehouses.Include(m => m.Employee).Include(m => m.WarehouseInventoryItems).ToListAsync();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _dbContext.Entry(warehouse).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }

}
