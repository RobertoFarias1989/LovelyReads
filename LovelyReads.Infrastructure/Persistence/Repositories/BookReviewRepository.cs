using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class BookReviewRepository : IBookReviewRepository
{
    private readonly LovelyReadsDbContext _dbContext;

    public BookReviewRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BookReview>> GetAllAsync()
    {
        return await _dbContext
            .BookReviews
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BookReview?> GetByIdAsync(int id)
    {
        return await _dbContext
            .BookReviews
            .AsNoTracking()
            .SingleOrDefaultAsync(br => br.Id == id);
    }

    public async Task<BookReview?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .BookReviews
            .AsNoTracking()
            .Include(br => br.User)
            .Include(br => br.Book)
            .SingleOrDefaultAsync(br => br.Id == id);

    }

    public async Task AddAsync(BookReview bookReview)
    {
        await _dbContext.BookReviews.AddAsync(bookReview);
    }

    public void UpdateAsync(BookReview bookReview)
    {
        _dbContext.BookReviews.Update(bookReview);
    }
}
