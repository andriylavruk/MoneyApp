namespace MoneyApp.Client.Services.ExpenseCategoryService;

public interface IExpenseCategoryService : IPaginationSearch
{
    List<ExpenseCategoryDTO> ExpenseCategories { get; set; }

    Task<ExpenseCategoryDTO> GetExpenseCategoryById(int id);
    Task CreateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO);
    Task UpdateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO);
    Task DeleteExpenseCategory(int id);
}
