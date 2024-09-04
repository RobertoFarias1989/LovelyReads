using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;

namespace LovelyReads.Core.Repositories;

public interface IUserBookReviewRepository
{
    Task<PaginationResult<UserBookReview>> GetAllAsync(string query, int page = 1);
    Task<UserBookReview?> GetByIdAsync(int id);
    Task<UserBookReview?> GetDetailsByIdAsync(int id);
    Task AddAsync(UserBookReview  userBookReview);

}
