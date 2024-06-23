using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class GenreRepository : IGenreRepository
{

    private readonly LovelyReadsDbContext _dbContext;

    public GenreRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Genre>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Genre> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Genre> GetDetailsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Genre genre)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Genre genre)
    {
        throw new NotImplementedException();
    }
}
