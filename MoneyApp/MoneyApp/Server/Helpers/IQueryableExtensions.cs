namespace MoneyApp.Server.Helpers;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, 
        PaginationDTO pagination)
    {
        if (pagination.QuantityPerPage >= 1)
        {
            return queryable
            .Skip((pagination.Page - 1) * pagination.QuantityPerPage)
            .Take(pagination.QuantityPerPage);
        }

        return queryable;
    }
}
