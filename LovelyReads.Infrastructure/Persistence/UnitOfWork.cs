using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace LovelyReads.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly LovelyReadsDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(LovelyReadsDbContext dbContext, 
        IUserRepository userRepository, 
        IBookRepository bookRepository,
        IUserBookRepository userBookRepository,
        IUserBookReviewRepository userBookReviewRepository,
        IGenreRepository genreRepository,
        IAuthorRepository authorRepository)
    {
        _dbContext = dbContext;
        UserRepository = userRepository;
        BookRepository = bookRepository;
        UserBookRepository = userBookRepository;
        UserBookReviewRepository = userBookReviewRepository;
        GenreRepository = genreRepository;
        AuthorRepository = authorRepository;
    }

    public IUserRepository UserRepository { get; }

    public IBookRepository BookRepository { get; }
    public IUserBookRepository UserBookRepository { get; }

    public IUserBookReviewRepository UserBookReviewRepository { get; }

    public IGenreRepository GenreRepository { get; }

    public IAuthorRepository AuthorRepository { get; }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction!.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction!.RollbackAsync();

            throw;
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
