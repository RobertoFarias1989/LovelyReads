using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LovelyReadsDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public AuthorRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Author>> GetAllAsync(string query, int page)
    {
        IQueryable<Author> authors = _dbContext.Authors;

        if(!string.IsNullOrWhiteSpace(query))
        {
            authors = authors.Where(a => a.Name.FullName.Contains(query));
        }

        return await authors.GetPaged<Author>(page, PAGE_SIZE);

        //return await _dbContext
        //    .Authors
        //    .AsNoTracking()
        //    .ToListAsync();
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
