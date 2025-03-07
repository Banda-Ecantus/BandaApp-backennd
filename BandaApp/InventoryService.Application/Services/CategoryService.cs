using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Application.Interfaces;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Shared.Domain;
using Shared.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IInventoryItemService inventoryItemService, ILogger<CategoryService> logger) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IInventoryItemService _inventoryItemService = inventoryItemService;
        private readonly ILogger<CategoryService> _logger = logger;

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryModel);
            return _mapper.Map<CategoryDto>(categoryModel);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            try
            {
                if (await _inventoryItemService.IsInvetoryItemVinculatedToCategory(id))
                {
                    throw new ValidationException("Existem itens vinculados a esta Categoria");
                }
                var category = await _categoryRepository.GetAsync(id) ?? throw new ValidationException("Categoria não encontrada");
                await _categoryRepository.DeleteAsync(category);
            }
            catch(ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{ErrorMessage}", ex.Message);
                throw new GenericException(SharedResources.UnexpectedError);
            }
           
        }

        public async Task<List<CategoryDto>> GetAllsAsync()
        {
            var result = _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAllAsync());
            return result;
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            var result = _mapper.Map<CategoryDto>(await _categoryRepository.GetAsync(id));
            return result;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateAsync(categoryModel);
            return _mapper.Map<CategoryDto>(categoryModel);
        }
    }
}
