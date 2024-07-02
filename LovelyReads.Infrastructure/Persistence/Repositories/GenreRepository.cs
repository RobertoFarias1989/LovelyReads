using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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
        return await _dbContext
            .Genres
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Genres
            .AsNoTracking()
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Genre?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .Genres
            .AsNoTracking()
            .Include(g => g.Books)
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddAsync(Genre genre)
    {
        await _dbContext.Genres.AddAsync(genre);
    }

    public void UpdateAsync(Genre genre)
    {
        _dbContext.Genres.Update(genre);
    }
}
