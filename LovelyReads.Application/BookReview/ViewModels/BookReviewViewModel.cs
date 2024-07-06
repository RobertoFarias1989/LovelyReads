namespace LovelyReads.Application.BookReview.ViewModels
{
    public class BookReviewViewModel
    {
        public BookReviewViewModel(int id, byte rating, string? comment, int idUser, int idBook)
        {
            Id = id;
            Rating = rating;
            Comment = comment;
            IdUser = idUser;
            IdBook = idBook;
        }

        public int Id { get; private set; }
        public byte Rating { get; private set; }
        public string? Comment { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
    }
}
