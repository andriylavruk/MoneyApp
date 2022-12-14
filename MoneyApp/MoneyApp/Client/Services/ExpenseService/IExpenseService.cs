namespace MoneyApp.Client.Services.ExpenseService;

public interface IExpenseService : IPaginationSearch
{
    List<ExpenseDTO>? Expenses { get; set; }

    Task<ExpenseDTO> GetExpenseById(int id);
    Task CreateExpense(ExpenseDTO expenseDTO);
    Task UpdateExpense(ExpenseDTO expenseDTO);
    Task DeleteExpense(int id);
}
