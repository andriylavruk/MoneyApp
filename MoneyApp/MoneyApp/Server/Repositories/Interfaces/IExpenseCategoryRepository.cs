namespace MoneyApp.Server.Repositories.Interfaces;

public interface IExpenseCategoryRepository
{
    IQueryable<ExpenseCategory> GetAllExpneseCategories();
    Task<ExpenseCategory> GetExpenseCategoryById(int id);
    Task CreateExpenseCategory(ExpenseCategory expenseCategory);
    Task UpdateExpenseCategory(ExpenseCategory expenseCategory);
    Task DeleteExpenseCategory(int id);
}
