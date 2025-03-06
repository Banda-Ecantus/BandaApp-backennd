using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Interfaces.Services;

namespace InventoryService.Application.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IInventoryItemRepository _repository;
        private readonly IMapper _mapper;

        public InventoryItemService(IInventoryItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<InventoryItemDto>> GetAllsAsync()
        {
            var result = _mapper.Map<List<InventoryItemDto>>(await _repository.GetAllAsync());
            return result;
        }

        public async Task<InventoryItemDto> GetInventoryItemAsync(Guid id)
        {
            var result = _mapper.Map<InventoryItemDto>(await _repository.GetAsync(id));
            return result;
        }

        public async Task<List<InventoryItemDto>> GetByCategoryAsync(Guid categoryId)
        {
            var result = _mapper.Map<List<InventoryItemDto>>(await _repository.GetByCategoryAsync(categoryId));
            return result;
        }

        public async Task<InventoryItemDto> CreateAsync(InventoryItemDto item)
        {

            var inventory = _mapper.Map<InventoryItem>(item);
            await _repository.CreateAsync(inventory);
            return _mapper.Map<InventoryItemDto>(inventory);
        }

        public async Task<InventoryItemDto> UpdateAsync(InventoryItemDto item)
        {

            var inventory = _mapper.Map<InventoryItem>(item);
            await _repository.UpdateAsync(inventory);
            return _mapper.Map<InventoryItemDto>(inventory);
        }

        public async Task DeleteInventoryItemAsync(Guid id)
        {
            var inventoryItem = await _repository.GetAsync(id);
            if (inventoryItem != null)
            {
                await _repository.DeleteAsync(inventoryItem);
            }
        }
    }
}
