using ShowService.Application.DTOS;

namespace ShowService.Application.Interfaces
{
    public interface IShowService
    {
        Task<List<ShowDto>> GetAllsAsync();
        Task<ShowDto> GetCategoryAsync(Guid id);
        Task<ShowDto> CreateAsync(ShowDto show);
        Task<ShowDto> UpdateAsync(ShowDto show);
        Task DeleteCategoryAsync(Guid id);
    }
}
