using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Domain;
using Shared.ExceptionHandling;

namespace InventoryService.Infrastructure.Repositories
{
    public class InventoryItemRepository(InventoryDbContext dbContext, ILogger<InventoryItemRepository> logger) : IInventoryItemRepository
    {
        private readonly InventoryDbContext _dbContext = dbContext;
        private readonly ILogger<InventoryItemRepository> _logger = logger;


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
            try
            {
                var result = await _dbContext.InventoryItems.ToListAsync();
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, SharedResources.inventoryRetrievalError);
                throw new ValidationException(SharedResources.inventoryRetrievalError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);
            }
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
