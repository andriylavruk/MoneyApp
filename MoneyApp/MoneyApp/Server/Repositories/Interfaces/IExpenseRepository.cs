namespace MoneyApp.Server.Repositories.Interfaces;

public interface IExpenseRepository
{
    IQueryable<Expense> GetAllExpneses();
    Task<Expense> GetExpenseById(int id);
    Task CreateExpense(Expense expense);
    Task UpdateExpense(Expense expense);
    Task DeleteExpense(int id);
}
