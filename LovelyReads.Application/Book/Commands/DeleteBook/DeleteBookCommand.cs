using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Book.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
