using MoneyApp.Shared.Models;

namespace MoneyApp.Client.Services.ExpenseCategoryService;

public interface IExpenseCategoryService
{
    List<ExpenseCategory> ExpenseCategories { get; set; }

    Task GetExpenseCategories();

    Task<ExpenseCategory> GetExpenseCategoryById(int id);
    Task CreateExpenseCategory(ExpenseCategory expenseCategory);
    Task UpdateExpenseCategory(ExpenseCategory expenseCategory);
    Task DeleteExpenseCategory(int id);
}
