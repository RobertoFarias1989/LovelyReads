using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class GenreRepository : IGenreRepository
{

    private readonly LovelyReadsDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public GenreRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Genre>> GetAllAsync(string query, int page)
    {
        IQueryable<Genre> genres = _dbContext.Genres;

        if (!string.IsNullOrEmpty(query))
        {
            genres = genres
                .Where(g =>
                g.Description.Contains(query));
        }

        return await genres.GetPaged<Genre>(page, PAGE_SIZE);

        //return await _dbContext
        //    .Genres
        //    .AsNoTracking()
        //    .ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Genres
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Genre?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .Genres
            .Include(g => g.Books)
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddAsync(Genre genre)
    {
        await _dbContext.Genres.AddAsync(genre);
    }

}
