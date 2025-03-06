using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Application.Interfaces;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryModel);
            return _mapper.Map<CategoryDto>(categoryModel);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id) ?? throw new Exception("Category not found");
            await _categoryRepository.DeleteAsync(category);
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
