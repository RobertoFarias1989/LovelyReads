using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.BookReview.Commands.CreateBookReview
{
    public class CreateBookReviewCommandHandler : IRequestHandler<CreateBookReviewCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookReviewCommand request, CancellationToken cancellationToken)
        {

            var bookReview = new Core.Entities.BookReview(
                request.Rating, request.Comment!, request.IdUser, request.IdBook);

            await _unitOfWork.BookReviewRepository.AddAsync(bookReview);

            await _unitOfWork.CompleteAsync();

            return bookReview.Id;

        }
    }
}
