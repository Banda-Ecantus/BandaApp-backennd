using Microsoft.Extensions.Logging;
using ShowService.Domain.Interfaces;
using ShowService.Infrastructure.Context;

namespace ShowService.Infrastructure.Repositories
{
    public class ShowRepository(ShowDbContext dbContext, ILogger<ShowRepository> logger) : IShowRepository
    {
        private readonly ShowDbContext _dbContext = dbContext;
        private readonly ILogger<ShowRepository> _logger = logger;

    }
}
