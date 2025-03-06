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
                await _dbContext.InventoryItems.AddAsync(inventory);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryCreationError);
                throw new ValidationException(SharedResources.inventoryCreationError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);
            }
        }

        public async Task DeleteAsync(InventoryItem inventory)
        {
            try
            {
                _dbContext.InventoryItems.Remove(inventory);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {

                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryDeletionError);
                throw new ValidationException(SharedResources.inventoryDeletionError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);

            }
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
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryRetrievalError);
                throw new ValidationException(SharedResources.inventoryRetrievalError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);
            }
        }

        public async Task<InventoryItem> GetAsync(Guid id)
        {
            try
            {
                var result = await _dbContext.InventoryItems.FirstOrDefaultAsync(x => x.Guid == id);
                return result;
            }
            catch (DbUpdateException dbEx)
            {

                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryRetrievalError);
                throw new ValidationException(SharedResources.inventoryRetrievalError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);
            }
        }

        public Task UpdateAsync(InventoryItem inventory)
        {
            try
            {

                _dbContext.InventoryItems.Update(inventory);
                return _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.inventoryUpdateError);
                throw new ValidationException(SharedResources.inventoryUpdateError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresInventoryError);
                throw new GenericException(SharedResources.postgresInventoryError);
            }
        }
    }
}
