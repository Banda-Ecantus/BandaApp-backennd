using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Domain.Interfaces;
using InventoryService.Interfaces.Services;

namespace InventoryService.Application.Services
{
    public class InvetoryItemService : IInventoryService
    {
        private readonly IInventoryItemRepository _repository;
        private readonly IMapper _mapper;

        public InvetoryItemService(IInventoryItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<InventoryItemDto>> GetAllsAsync()
        {
            var result = _mapper.Map<List<InventoryItemDto>>(await _repository.GetAllAsync());
            return result;
        }

        public Task<InventoryItemDto> GetInventoryItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryItemDto> CreateInventoryItemAsync(InventoryItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryItemDto> UpdateInventoryItemAsync(InventoryItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInventoryItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
