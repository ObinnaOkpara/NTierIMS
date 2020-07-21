using Microsoft.EntityFrameworkCore;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;
using NTierIMS.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierIMS.Infrastructure.Services
{
    public class DeliveryService : IDeliveryService
    {
        protected readonly ApplicationDbContext _dbContext;

        public DeliveryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Delivery> AddAsync(Delivery item)
        {
            var warehouseItem = await _dbContext.WarehouseInventoryItems
                .FirstOrDefaultAsync(m => m.InventoryItemId == item.InventoryItemId && m.WarehouseId == item.WarehouseId);
            
            if (warehouseItem != null)
            {
                warehouseItem.ItemCount += item.NumberOfItemDelivered;
                warehouseItem.LastUpdated = DateTime.Now;
            }
            else
            {
                warehouseItem = new WarehouseInventoryItem()
                {
                    InventoryItemId = item.InventoryItemId,
                    ItemCount = item.NumberOfItemDelivered,
                    WarehouseId = item.WarehouseId,
                    LastUpdated = DateTime.Now
                };
                _dbContext.WarehouseInventoryItems.Add(warehouseItem);
            }

            await _dbContext.Deliveries.AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(Delivery item)
        {
            _dbContext.Deliveries.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Delivery> GetByIdAsync(int id)
        {
            return await _dbContext.Deliveries.Include(m => m.Warehouse).Include(m => m.Employee)
                .Include(m => m.InventoryItem).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Delivery>> ListAllAsync()
        {
            return await _dbContext.Deliveries.Include(m => m.Warehouse).Include(m => m.Employee)
                .Include(m => m.InventoryItem).ToListAsync();
        }

        public async Task UpdateAsync(Delivery item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
