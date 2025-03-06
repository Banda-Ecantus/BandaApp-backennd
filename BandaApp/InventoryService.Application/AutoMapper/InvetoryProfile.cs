using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Domain.Models;

namespace InventoryService.Application.AutoMapper
{
    public class InvetoryProfile : Profile
    {

        public InvetoryProfile()
        {
            CreateMap<InventoryItem, InventoryItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
