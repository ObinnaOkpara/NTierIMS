using NTierIMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTierIMS.Core.Interfaces
{
    public interface IRemovalService
    {
        Task<Removal> GetByIdAsync(int id);
        Task<IReadOnlyList<Removal>> ListAllAsync();
        Task<string> AddAsync(Removal entity);
        Task UpdateAsync(Removal entity);
        Task DeleteAsync(Removal entity);
    }
}
