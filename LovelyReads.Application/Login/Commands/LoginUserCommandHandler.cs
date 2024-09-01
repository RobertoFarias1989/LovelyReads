using LovelyReads.Application.Login.ViewModels;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.Services;
using MediatR;

namespace LovelyReads.Application.Login.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginUserViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Utilizar o mesmo algoritmo para criar o hash dessa senha
        var passwordHash = _authService.ComputeSha256Hash(request.PasswordValue!);

        //Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
        var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordAsync(request.EmailAddress!, passwordHash);

        //Se não existir, erro no login
        if (user == null)
            return Result.Fail<LoginUserViewModel>(UserErrors.NotFound);

        //Se existir, gero o token usando os dados do usuário
        var token = _authService.GenerateJwtToken(user.Email.EmailAddress, user.Role);

        return Result.Ok(new LoginUserViewModel(user.Email.EmailAddress, token));
    }
}
