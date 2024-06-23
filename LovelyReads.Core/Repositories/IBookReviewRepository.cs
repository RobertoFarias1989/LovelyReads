using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IBookReviewRepository
{
    Task<List<BookReview>> GetAllAsync();
    Task<BookReview> GetByIdAsync(int id);
    Task<BookReview> GetDetailsByIdAsync(int id);
    Task AddAsync(BookReview bookReview);
    Task UpdateAsync(BookReview bookReview);
}
