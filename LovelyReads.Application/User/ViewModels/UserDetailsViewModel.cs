using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Application.UserBookReview.ViewModels;

namespace LovelyReads.Application.User.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(string street,
        string city,
        string state,
        string postalCode,
        string country,
        string cPFNumber,
        string emailAddress,
        string fullName,
        string passwordValue,
        bool isDeleted, DateTime createdAt, DateTime? updatedAt, List<UserBookReviewViewModel> bookReviews)
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
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        BookReviews = bookReviews;
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public string CPFNumber { get; private set; }
    public string EmailAddress { get; private set; }
    public string FullName { get; private set; }
    public string PasswordValue { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<UserBookReviewViewModel> BookReviews { get; private set; }
}
