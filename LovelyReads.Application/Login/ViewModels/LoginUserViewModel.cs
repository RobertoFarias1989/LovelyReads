namespace LovelyReads.Application.Login.ViewModels;

public class LoginUserViewModel
{
    public LoginUserViewModel(string emailAddress, string token)
    {
        EmailAddress = emailAddress;
        Token = token;
    }

    public string EmailAddress { get; private set; }
    public string Token { get; private set; }
}
