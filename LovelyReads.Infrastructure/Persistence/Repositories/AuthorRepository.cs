using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LovelyReadsDbContext _dbContext;

    public AuthorRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _dbContext
            .Authors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Authors      
            .SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Author?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .Authors
            .Include(a => a.Books)    
            .SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
    }

}
