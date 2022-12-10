namespace MoneyApp.Client.Services.ExpenseService;

public interface IExpenseService
{
    List<Expense>? Expenses { get; set; }

    Task GetExpenses();

    Task<Expense> GetExpenseById(int id);
    Task CreateExpense(Expense expense);
    Task UpdateExpense(Expense expense);
    Task DeleteExpense(int id);
}
