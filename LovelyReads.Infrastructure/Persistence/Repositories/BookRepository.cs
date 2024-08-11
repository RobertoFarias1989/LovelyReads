using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LovelyReadsDbContext _dbContext;

    public BookRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext
            .Books
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Books     
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Book?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .Books
            .Include(b => b.UserBooks)    
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

}
