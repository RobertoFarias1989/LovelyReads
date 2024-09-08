namespace LovelyReads.Core.DTOs;

public class UserBookDTO
{
    //Construtor para não dar erro quando efetuar a query no banco
    public UserBookDTO()
    {
        
    }

    //Construtor para ser chamado nos Testes Unitários
    public UserBookDTO(int id,
        int idUser,
        int idBook,
        DateTime startToReadAt,
        DateTime? finishReadAt, short pageAmountReaded, short pageAmountToFinishRead)
    {
        Id = id;
        IdUser = idUser;
        IdBook = idBook;
        StartToReadAt = startToReadAt;
        FinishReadAt = finishReadAt;
        PageAmountReaded = pageAmountReaded;
        PageAmountToFinishRead = pageAmountToFinishRead;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
    public DateTime StartToReadAt { get; private set; }
    public DateTime? FinishReadAt { get; private set; }
    public short PageAmountReaded { get; private set; }
    public short PageAmountToFinishRead { get; private set; }
}
