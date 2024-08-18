using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class UserBookReviewRepository : IUserBookReviewRepository
{
    private readonly LovelyReadsDbContext _dbContext;

    public UserBookReviewRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserBookReview>> GetAllAsync()
    {
        return await _dbContext
            .UserBookReviews
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<UserBookReview?> GetByIdAsync(int id)
    {
        return await _dbContext
            .UserBookReviews
            .SingleOrDefaultAsync(br => br.Id == id);
    }

    public async Task<UserBookReview?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .UserBookReviews
            .Include(br => br.User)
            .Include(br => br.UserBook)
            .Include (br => br.UserBook!.Book)
            .SingleOrDefaultAsync(br => br.Id == id);

    }

    public async Task AddAsync(UserBookReview bookReview)
    {
        await _dbContext.UserBookReviews.AddAsync(bookReview);
    }

}
