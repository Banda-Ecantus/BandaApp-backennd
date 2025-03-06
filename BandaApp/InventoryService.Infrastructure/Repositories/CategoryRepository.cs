using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Domain;
using Shared.ExceptionHandling;

namespace InventoryService.Infrastructure.Repositories
{
    public class CategoryRepository(InventoryDbContext dbContext, ILogger<CategoryRepository> logger) : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger = logger;
        private readonly InventoryDbContext _dbContext = dbContext;

        public async Task CreateAsync(Category category)
        {
            try
            {
                await _dbContext.Category.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.categoryCreationError);
                throw new ValidationException(SharedResources.categoryCreationError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);

            }

        }

        public async Task DeleteAsync(Category category)
        {

            try
            {
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.categoryDeletionError);
                throw new ValidationException(SharedResources.categoryDeletionError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }   
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Category.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }

        public async Task<Category> GetAsync(Guid id)
        {
            try
            {
                return await _dbContext.Category.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                _dbContext.Category.Update(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "{ErrorMessage}", SharedResources.categoryUpdateError);
                throw new ValidationException(SharedResources.categoryUpdateError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", SharedResources.postgresError);
                throw new GenericException(SharedResources.postgresError);
            }
        }
    }
}
