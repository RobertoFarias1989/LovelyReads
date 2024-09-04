using LovelyReads.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.ExtensionMethods;

public static class PaginationResultExtension
{
    //método de extensão construído em cima do IQueryable
    //será usado em cima do dbContext quando estivermos lidando com a consulta
    //diretamente do EF
    public static async Task<PaginationResult<T>> GetPaged<T>(
        this IQueryable<T> query,
        int page,
        int pageSize) where T : class
    {
        var result = new PaginationResult<T>();

        result.Page = page;
        result.PageSize = pageSize;
        result.ItemsCount = await query.CountAsync();

        var pageCount = (double)result.ItemsCount / pageSize;
        result.TotalPages = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;

        result.Data = await query.Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();

        return result;
    }
}
