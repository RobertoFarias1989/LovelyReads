using Dapper;
using LovelyReads.Core.DTOs;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class UserBookRepository : IUserBookRepository
{
    private readonly LovelyReadsDbContext _dbContext;
    private readonly string _connectionString;

    public UserBookRepository(LovelyReadsDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("LovelyReads");
    }

    public async Task<List<UserBook>> GetAllAsync()
    {
        return await _dbContext.UserBooks.AsNoTracking().ToListAsync();
    }

    public async Task<List<UserBookDTO>> GetAllBooksReadedAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var sqlScript = "SELECT Id" +
                ",IdUser" +
                ",IdBook" +
                ",StartToReadAt" +
                ",FinishReadAt" +
                ",PageAmountReaded" +
                " PageAmountToFinishRead" +
                " FROM UserBooks WHERE IsDeleted <> 1";

            var userBooks = await sqlConnection.QueryAsync<UserBookDTO>(sqlScript);

            return userBooks.ToList();

        }
    }

    public async Task<UserBook?> GetByIdAsync(int id)
    {
        return await _dbContext.UserBooks.SingleOrDefaultAsync(ub => ub.Id == id);
    }

    public async Task<UserBook?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .UserBooks
            .Include(ub => ub.Reviews)
            .Include(ub => ub.User)
            .Include(ub => ub.Book)
            .SingleOrDefaultAsync(ub => ub.Id == id);
    }
    public async Task AddAsync(UserBook userBook)
    {
        await _dbContext.UserBooks.AddAsync(userBook);
    }

}
