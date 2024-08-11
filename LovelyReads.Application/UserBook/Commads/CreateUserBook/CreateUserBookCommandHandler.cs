using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.CreateUserBook;

public class CreateUserBookCommandHandler : IRequestHandler<CreateUserBookCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserBookCommand request, CancellationToken cancellationToken)
    {

        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.IdBook);

        var userBook = new Core.Entities.UserBook(request.IdUser, request.IdBook, book!.PageAmount);

        await _unitOfWork.UserBookRepository.AddAsync(userBook);

        await _unitOfWork.CompleteAsync();

        return userBook.Id;

    }
}
