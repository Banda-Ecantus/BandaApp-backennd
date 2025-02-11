using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Repositories
{
    public class InventoryItemRepository(InventoryDbContext dbContext) : IInventoryItemRepository
    {
        private readonly InventoryDbContext _dbContext = dbContext;

        public Task AddAsync(InventoryItem inventory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(InventoryItem inventory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            var result = await _dbContext.InventoryItems.ToListAsync();
            return result;
        }

        public Task<InventoryItem> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InventoryItem inventory)
        {
            throw new NotImplementedException();
        }
    }
}
