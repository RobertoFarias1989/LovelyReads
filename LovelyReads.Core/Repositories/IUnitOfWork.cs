namespace LovelyReads.Core.Repositories;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IBookRepository BookRepository { get; }
    public IBookReviewRepository BookReviewRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}
