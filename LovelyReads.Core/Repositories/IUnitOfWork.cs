namespace LovelyReads.Core.Repositories;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IBookRepository BookRepository { get; }
    public IUserBookRepository UserBookRepository { get; }
    public IUserBookReviewRepository  UserBookReviewRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}
