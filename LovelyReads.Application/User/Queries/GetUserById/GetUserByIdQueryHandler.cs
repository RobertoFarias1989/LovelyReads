using LovelyReads.Application.BookReview.ViewModels;
using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
{
    private readonly IUnitOfWork? _unitOfWork;

    public GetUserByIdQueryHandler(IUnitOfWork? unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork!.UserRepository.GetDetailsByIdAsync(request.Id);
        UserDetailsViewModel userDetailsViewModel;

        if (user == null)
            throw new Exception($"The user with id:{request.Id} was not found.");


        if (user.BookReviews != null)
        {
            var bookReviews = user.BookReviews
                .Where(br => br.IdUser == user.Id)
                .Select(br => new BookReviewViewModel(
                    br.Id,
                    br.Rating,
                    br.Comment,
                    br.IdUser,
                    br.IdBook))
                .ToList();

            userDetailsViewModel = new UserDetailsViewModel(
                user.Address.Street,
                user.Address.City,
                user.Address.State,
                user.Address.PostalCode,
                user.Address.Country,
                user.CPF.CPFNumber,
                user.Email.EmailAddress,
                user.Name.FullName,
                user.Password.PasswordValue,
                bookReviews);

        }

        userDetailsViewModel = new UserDetailsViewModel(
               user.Address.Street,
               user.Address.City,
               user.Address.State,
               user.Address.PostalCode,
               user.Address.Country,
               user.CPF.CPFNumber,
               user.Email.EmailAddress,
               user.Name.FullName,
               user.Password.PasswordValue,
               new List<BookReviewViewModel>());


        return userDetailsViewModel;
    }
}
