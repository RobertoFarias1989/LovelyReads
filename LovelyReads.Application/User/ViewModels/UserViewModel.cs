namespace LovelyReads.Application.User.ViewModels;

public class UserViewModel
{
    public UserViewModel(string? street,
        string? city,
        string? state,
        string? postalCode,
        string? country,
        string? cPFNumber, string? emailAddress, string? fullName, string? passwordValue)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        CPFNumber = cPFNumber;
        EmailAddress = emailAddress;
        FullName = fullName;
        PasswordValue = passwordValue;
    }

    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? PostalCode { get; private set; }
    public string? Country { get; private set; }
    public string? CPFNumber { get; private set; }
    public string? EmailAddress { get; private set; }
    public string? FullName { get; private set; }
    public string? PasswordValue { get; private set; }
}
