using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class UserBookReviewRepository : IUserBookReviewRepository
{
    private readonly LovelyReadsDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public UserBookReviewRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<UserBookReview>> GetAllAsync(string query, int page)
    {

        IQueryable<UserBookReview> userBookReviews = _dbContext.UserBookReviews;

        if (!string.IsNullOrEmpty(query))
        {
            userBookReviews = userBookReviews
                .Where(b =>
                b.User!.Name.FullName.Contains(query));
        }

        return await userBookReviews.GetPaged<UserBookReview>(page, PAGE_SIZE);

        //return await _dbContext
        //    .UserBookReviews
        //    .AsNoTracking()
        //    .ToListAsync();
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
