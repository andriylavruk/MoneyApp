using MoneyApp.Shared.Models;

namespace MoneyApp.Client.Services.ExpenseCategoryService;

public interface IExpenseCategoryService
{
    List<ExpenseCategoryDTO> ExpenseCategories { get; set; }

    Task GetExpenseCategories();

    Task<ExpenseCategoryDTO> GetExpenseCategoryById(int id);
    Task CreateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO);
    Task UpdateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO);
    Task DeleteExpenseCategory(int id);
}
