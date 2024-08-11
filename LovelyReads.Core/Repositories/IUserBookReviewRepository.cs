using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IUserBookReviewRepository
{
    Task<List<UserBookReview>> GetAllAsync();
    Task<UserBookReview?> GetByIdAsync(int id);
    Task<UserBookReview?> GetDetailsByIdAsync(int id);
    Task AddAsync(UserBookReview  userBookReview);

}
