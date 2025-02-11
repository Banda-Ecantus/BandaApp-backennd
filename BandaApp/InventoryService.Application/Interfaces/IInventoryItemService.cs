using InventoryService.Application.DTOS;

namespace InventoryService.Interfaces.Services
{
    public interface IInventoryItemService
    {
        Task<List<InventoryItemDto>> GetAllsAsync();
        Task<InventoryItemDto> GetInventoryItemAsync(Guid id);
        Task<InventoryItemDto> CreateInventoryItemAsync(InventoryItemDto item);
        Task<InventoryItemDto> UpdateInventoryItemAsync(InventoryItemDto item);
        Task DeleteInventoryItemAsync(Guid id);
    }
}
