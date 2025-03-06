using InventoryService.Application.DTOS;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllsAsync();
        Task<CategoryDto> GetCategoryAsync(Guid id);
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<CategoryDto> UpdateAsync(CategoryDto category);
        Task DeleteCategoryAsync(Guid id);
    }
}
