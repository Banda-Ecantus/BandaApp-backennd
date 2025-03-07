using InventoryService.Application.DTOS;

namespace InventoryService.Interfaces.Services
{
    public interface IInventoryItemService
    {
        Task<List<InventoryItemDto>> GetAllsAsync();
        Task<InventoryItemDto> GetInventoryItemAsync(Guid id);
        Task<InventoryItemDto> CreateAsync(InventoryItemDto item);
        Task<InventoryItemDto> UpdateAsync(InventoryItemDto item);
        Task DeleteInventoryItemAsync(Guid id);
        Task<bool> IsInvetoryItemVinculatedToCategory(Guid id);
    }
}
