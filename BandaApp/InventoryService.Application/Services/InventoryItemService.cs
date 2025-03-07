using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Shared.Domain;
using Shared.ExceptionHandling;

namespace InventoryService.Application.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IInventoryItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<InventoryItemService> _logger;

        public InventoryItemService(IInventoryItemRepository repository, IMapper mapper, ILogger<InventoryItemService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
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

        public async Task<InventoryItemDto> CreateAsync(InventoryItemDto item)
        {
            var inventory = _mapper.Map<InventoryItem>(item);
            try
            {
                if (await _repository.SerialNumberExistsAsync(item.SerialNumber))
                {
                    throw new ValidationException("Número de Série deve ser único."); //TODO: Resolver mensagem de SharedResource null
                }
                await _repository.CreateAsync(inventory);
                var result = await _repository.GetAsync(inventory.Guid);
                return _mapper.Map<InventoryItemDto>(result);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", ex.Message);
                throw new GenericException(SharedResources.UnexpectedError);
            }
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
