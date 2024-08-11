using MediatR;
using Microsoft.AspNetCore.Http;

namespace LovelyReads.Application.Book.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {  
        public string? Title { get;  set; }
        public string? Description { get;  set; }
        public int EditionNumber { get; set; }
        public string? EditionDescription { get; set; }
        public string? ISBN { get;  set; }
        public int IdAuthor { get;  set; }
        public string? Publisher { get;  set; }
        public int IdGenre { get;  set; }
        public short PublishedYear { get;  set; }
        public short PageAmount { get;  set; }        
        public IFormFile? BookCover { get;  set; }
    }
}
