using NTierIMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTierIMS.Core.Interfaces
{
    public interface IWarehouseService
    {
        Task<Warehouse> GetByIdAsync(int id);
        Task<IReadOnlyList<Warehouse>> ListAllAsync();
        Task<Warehouse> AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(Warehouse warehouse);
    }
}
