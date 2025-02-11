using AutoMapper;
using InventoryService.Application.DTOS;
using InventoryService.Domain.Models;

namespace InventoryService.Application.AutoMapper
{
    public class InvetoryItemProfile : Profile
    {

        public InvetoryItemProfile()
        {
            CreateMap<InventoryItem, InventoryItemDto>().ReverseMap();
        }
    }
}
