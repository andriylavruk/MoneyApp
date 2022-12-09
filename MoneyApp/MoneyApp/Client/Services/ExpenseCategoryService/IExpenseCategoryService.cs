using MoneyApp.Shared.Models;

namespace MoneyApp.Client.Services.ExpenseCategoryService
{
    public interface IExpenseCategoryService
    {
        List<ExpenseCategory> ExpenseCategories { get; set; }

        Task GetExpenseCategories();

        Task<ExpenseCategory> GetExpenseCategoryById(Guid id);
    }
}
