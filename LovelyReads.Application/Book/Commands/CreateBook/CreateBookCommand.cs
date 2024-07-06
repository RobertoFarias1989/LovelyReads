using MediatR;

namespace LovelyReads.Application.Book.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string ISBN { get;  set; }
        public int IdAuthor { get;  set; }
        public string Publisher { get;  set; }
        public int IdGenre { get;  set; }
        public short PublishedYear { get;  set; }
        public short PageAmount { get;  set; }
        public decimal AverageRating { get;  set; }
        public byte BookCover { get;  set; }
    }
}
