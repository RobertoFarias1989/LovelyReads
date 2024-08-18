using LovelyReads.Core.Errors;
using LovelyReads.Core.Results;

namespace LovelyReads.Core.Entities;

public class UserBook : BaseEntity
{
    public UserBook(int idUser, int idBook, short pageAmountToFinishRead)
    {
        IdUser = idUser;
        IdBook = idBook;               
        PageAmountToFinishRead = pageAmountToFinishRead;

        StartToReadAt = DateTime.Now;
        PageAmountReaded = 0;
        FinishReadAt = null;
        CreatedAt = DateTime.Now;
        UpdatedAt = null;
        IsDeleted = false;
        Reviews = new List<UserBookReview>();
       
    }

    public int IdUser { get; private set; }
    public User? User { get; private set; }
    public int IdBook { get; private set; }
    public Book? Book { get; private set; }
    public DateTime StartToReadAt { get; private set; }
    public DateTime? FinishReadAt { get; private set; }
    public short PageAmountReaded { get; private set; }
    public short PageAmountToFinishRead { get; private set; }
    public List<UserBookReview>? Reviews { get; private set; }

    public void UpdatePageAmountReaded()
    {
        PageAmountReaded++;

        //TODO: criar uma propriedade para guardar o total de páginas ou uma pra ir sendo reduzida conforme a PageAmountReaded vai sendo incrementada? 
        //PageAmountToFinishRead--;

        UpdatedAt = DateTime.Now;
    }

    public Result FinishRead()
    {
        if (PageAmountReaded == 0)
            return Result.Fail(UserBookErrors.PageAmountReadedCannotBeZero);

        FinishReadAt = DateTime.Now;

        UpdatedAt = DateTime.Now;

        return Result.Ok();
    }

}
