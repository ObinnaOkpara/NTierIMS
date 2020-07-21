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
    public class RemovalService : IRemovalService
    {

        protected readonly ApplicationDbContext _dbContext;

        public RemovalService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddAsync(Removal item)
        {
            var warehouseItem = await _dbContext.WarehouseInventoryItems
                .FirstOrDefaultAsync(m => m.InventoryItemId == item.InventoryItemId || m.WarehouseId == item.WarehouseId);

            if (warehouseItem != null)
            {
                if (warehouseItem.ItemCount >= item.NumberOfItemRemoved)
                {
                    warehouseItem.ItemCount -= item.NumberOfItemRemoved;
                    warehouseItem.LastUpdated = DateTime.Now;
                }
                else
                {
                    return ($"Error: Not enough items in stock. Total in stock - {warehouseItem.ItemCount}");
                }
            }
            else
            {
                warehouseItem = new WarehouseInventoryItem()
                {
                    InventoryItemId = item.InventoryItemId,
                    ItemCount = 0,
                    WarehouseId = item.WarehouseId,
                    LastUpdated = DateTime.Now
                };

                return ($"Error: Not enough items in stock. Total in stock - {warehouseItem.ItemCount}");
            }

            await _dbContext.Removals.AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return "Removal recorded successfully.";
        }

        public async Task DeleteAsync(Removal item)
        {
            _dbContext.Removals.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Removal> GetByIdAsync(int id)
        {
            return await _dbContext.Removals.Include(m => m.Warehouse).Include(m => m.Employee)
                .Include(m => m.InventoryItem).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Removal>> ListAllAsync()
        {
            return await _dbContext.Removals.Include(m => m.Warehouse).Include(m => m.Employee)
                .Include(m => m.InventoryItem).ToListAsync();
        }

        public async Task UpdateAsync(Removal item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }

}
