namespace MoneyApp.Server.Helpers;

public static class HttpContextExtensions
{
    public static async Task InsertPaginationParameterInResoponse<T>(this HttpContext httpContext,
        IQueryable<T> queryable, int recordsPerPage)
    {
        double count = await queryable.CountAsync();
        double pagesQuantity = Math.Ceiling(count / recordsPerPage);
        httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
    }
}
