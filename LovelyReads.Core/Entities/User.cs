using LovelyReads.Core.ValueObjects;

namespace LovelyReads.Core.Entities;

public class User : BaseEntity
{
    public User(Address address, CPF cPF, Email email, Name name, Password password)
    {
        Address = address;
        CPF = cPF;
        Email = email;
        Name = name;
        Password = password;

        UpdatedAt = null;
        BookReviews = new List<BookReview>();
    }

    public Address Address { get; private set; }
    public CPF CPF { get; private set; }
    public Email  Email { get; private set; }
    public Name  Name { get; private set; }
    public Password  Password { get; private set; }
    public List<BookReview> BookReviews { get; private set; }
}
