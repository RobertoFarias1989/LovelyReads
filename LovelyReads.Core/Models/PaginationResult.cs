namespace LovelyReads.Core.Models;

public class PaginationResult<T>
{
    public PaginationResult()
    {
        //Quando fizermos a consulta diretamento do banco de dados
        //ele usará esse construtor
    }

    public PaginationResult(int page, int totalPages, int pageSize, int itemsCount, List<T> data)
    {
        //Quando formos mapear o que trouxemos do banco de dados para o modelo da camada de aplicação
        //usaremos esse segundo construtor
        Page = page;
        TotalPages = totalPages;
        PageSize = pageSize;
        ItemsCount = itemsCount;
        Data = data;
    }

    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int ItemsCount { get; set; }
    public List<T> Data { get; set; }
}
