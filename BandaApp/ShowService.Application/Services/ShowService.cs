using AutoMapper;
using ShowService.Application.DTOS;
using ShowService.Application.Interfaces;
using ShowService.Domain.Interfaces;

namespace ShowService.Application.Services
{
    public class ShowService(IShowRepository repository, IMapper mapper) : IShowService
    {
        private readonly IShowRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public Task<ShowDto> CreateAsync(ShowDto show)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShowDto>> GetAllsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ShowDto> GetCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShowDto> UpdateAsync(ShowDto show)
        {
            throw new NotImplementedException();
        }
    }
}
