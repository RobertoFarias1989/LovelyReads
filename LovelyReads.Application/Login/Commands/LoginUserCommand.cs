using LovelyReads.Application.Login.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Login.Commands
{
    public class LoginUserCommand : IRequest<Result<LoginUserViewModel>>
    {
        public string? EmailAddress { get;  set; }
        public string? PasswordValue { get; set; }
    }
}
