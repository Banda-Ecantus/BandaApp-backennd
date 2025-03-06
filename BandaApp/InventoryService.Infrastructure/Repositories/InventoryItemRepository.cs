using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Context;
using Microsoft.AspNetCore.Routing.Tree;
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

        public async Task CreateAsync(InventoryItem inventory)
        {
            try
            {
                await _dbContext.InventoryItem.AddAsync(inventory);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryCreationError);
                throw new ValidationException(SharedResources.inventoryCreationError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }

        public async Task DeleteAsync(InventoryItem inventory)
        {
            try
            {
                _dbContext.InventoryItem.Remove(inventory);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {

                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryDeletionError);
                throw new ValidationException(SharedResources.inventoryDeletionError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);

            }
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.InventoryItem.Include(c => c.Category).ToListAsync();
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryRetrievalError);
                throw new ValidationException(SharedResources.inventoryRetrievalError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }

        public async Task<InventoryItem> GetAsync(Guid id)
        {
            try
            {
                var result = await _dbContext.InventoryItem.Include(c => c.Category).FirstOrDefaultAsync(x => x.Guid == id);
                return result;
            }
            catch (DbUpdateException dbEx)
            {

                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryRetrievalError);
                throw new ValidationException(SharedResources.inventoryRetrievalError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }


        public Task UpdateAsync(InventoryItem inventory)
        {
            try
            {

                _dbContext.InventoryItem.Update(inventory);
                return _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryUpdateError);
                throw new ValidationException(SharedResources.inventoryUpdateError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }
    }
}
