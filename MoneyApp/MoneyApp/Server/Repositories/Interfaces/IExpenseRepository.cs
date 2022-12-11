namespace MoneyApp.Server.Repositories.Interfaces;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetAllExpneses();
    Task<Expense> GetExpenseById(int id);
    Task CreateExpense(Expense expense);
    Task UpdateExpense(Expense expense);
    Task DeleteExpense(int id);
}
