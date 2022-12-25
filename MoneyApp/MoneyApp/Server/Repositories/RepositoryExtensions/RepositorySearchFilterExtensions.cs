namespace MoneyApp.Server.Repositories.RepositoryExtensions;

public static class RepositorySearchFilterExtensions
{
    public static IQueryable<ExpenseCategory> Search(this IQueryable<ExpenseCategory> queryable, string? searchFilter)
    {
        if (string.IsNullOrWhiteSpace(searchFilter))
        {
            return queryable;
        }

        var SearchTerm = searchFilter.Trim();

        return queryable.Where(p => p.CategoryName.Contains(SearchTerm));
    }

    public static IQueryable<Expense> Search(this IQueryable<Expense> queryable, string? searchFilter)
    {
        if (string.IsNullOrWhiteSpace(searchFilter))
        {
            return queryable;
        }

        var SearchTerm = searchFilter.Trim();

        return queryable.Where(p => p.Description.Contains(SearchTerm)
            || p.DateCreated.ToString().Contains(SearchTerm)
            || p.Amount.ToString().Contains(SearchTerm)
            || p.ExpenseCategory.CategoryName.Contains(SearchTerm));
    }

    public static IQueryable<IncomeCategory> Search(this IQueryable<IncomeCategory> queryable, string? searchFilter)
    {
        if (string.IsNullOrWhiteSpace(searchFilter))
        {
            return queryable;
        }

        var SearchTerm = searchFilter.Trim();

        return queryable.Where(p => p.CategoryName.Contains(SearchTerm));
    }

    public static IQueryable<Income> Search(this IQueryable<Income> queryable, string? searchFilter)
    {
        if (string.IsNullOrWhiteSpace(searchFilter))
        {
            return queryable;
        }

        var SearchTerm = searchFilter.Trim();

        return queryable.Where(p => p.Description.Contains(SearchTerm)
            || p.DateCreated.ToString().Contains(SearchTerm)
            || p.Amount.ToString().Contains(SearchTerm)
            || p.IncomeCategory.CategoryName.Contains(SearchTerm));
    }
}
