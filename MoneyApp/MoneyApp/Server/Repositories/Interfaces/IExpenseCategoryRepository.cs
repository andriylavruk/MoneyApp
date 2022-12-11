namespace MoneyApp.Server.Repositories.Interfaces;

public interface IExpenseCategoryRepository
{
    Task<IEnumerable<ExpenseCategory>> GetAllExpneseCategories();
    Task<ExpenseCategory> GetExpenseCategoryById(int id);
    Task CreateExpenseCategory(ExpenseCategory expenseCategory);
    Task UpdateExpenseCategory(ExpenseCategory expenseCategory);
    Task DeleteExpenseCategory(int id);
}
