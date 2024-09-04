using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LovelyReadsDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public BookRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Book>> GetAllAsync(string query, int page)
    {

        IQueryable<Book> books = _dbContext.Books;

        if (!string.IsNullOrEmpty(query))
        {
            books = books
            .Where(b =>
                b.Title.Contains(query)
                || b.Author!.Name.FullName.Contains(query)
                || b.PublishedYear.ToString().Contains(query));
        }

        return await books.GetPaged<Book>(page, PAGE_SIZE);

        //return await _dbContext
        //    .Books
        //    .AsNoTracking()
        //    .ToListAsync();
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
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

}
