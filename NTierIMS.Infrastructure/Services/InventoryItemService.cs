using Microsoft.EntityFrameworkCore;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;
using NTierIMS.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTierIMS.Infrastructure.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        protected readonly ApplicationDbContext _dbContext;

        public InventoryItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InventoryItem> AddAsync(InventoryItem item)
        {
            await _dbContext.InventoryItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(InventoryItem item)
        {
            _dbContext.InventoryItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InventoryItem> GetByIdAsync(int id)
        {
            return await _dbContext.InventoryItems.Include(m=>m.WarehouseInventoryItems)
                .ThenInclude(n=> n.Warehouse).Include(m => m.Employee).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<InventoryItem>> ListAllAsync()
        {
            return await _dbContext.InventoryItems.Include(m => m.WarehouseInventoryItems).ToListAsync();
        }

        public async Task UpdateAsync(InventoryItem item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
