using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetAllAsync();
    Task<Genre?> GetByIdAsync(int id);
    Task<Genre?> GetDetailsByIdAsync(int id);
    Task AddAsync(Genre genre);
    void UpdateAsync(Genre genre);
    //Task UpdateAsync(Genre genre);
}
