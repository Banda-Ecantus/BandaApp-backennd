using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces
{
    public  interface IInventoryItemRepository
    {
        Task CreateAsync(InventoryItem inventory);
        Task DeleteAsync(InventoryItem inventory);
        Task<InventoryItem> GetAsync(Guid id);
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task UpdateAsync(InventoryItem inventory);
    }
}
