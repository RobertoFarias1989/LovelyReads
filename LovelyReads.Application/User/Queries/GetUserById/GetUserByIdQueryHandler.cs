using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;
using LovelyReads.Core.Results;
using LovelyReads.Core.Errors;

namespace LovelyReads.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDetailsViewModel>>
{
    private readonly IUnitOfWork? _unitOfWork;

    public GetUserByIdQueryHandler(IUnitOfWork? unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserDetailsViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork!.UserRepository.GetDetailsByIdAsync(request.Id);
        UserDetailsViewModel userDetailsViewModel;

        if (user == null)
            return Result.Fail<UserDetailsViewModel>(UserErrors.NotFound);            

        //TODO: ver qual lista exibir se a de Review ou de UserBook

        if (user.BookReviews.Count > 0)
        {
            var bookReviews = user.BookReviews
                .Where(br => br.IdUser == user.Id)
                .Select(br => new UserBookReviewViewModel(
                    br.Id,
                    br.Rating,
                    br.Comment,
                    br.IdUser,
                    br.IdUserBook))
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
                user.Role,
                user.IsDeleted,
                user.CreatedAt,
                user.UpdatedAt,
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
               user.Role,
               user.IsDeleted,
               user.CreatedAt,
               user.UpdatedAt,
               new List<UserBookReviewViewModel>());


        return Result.Ok(userDetailsViewModel);
    }
}
