using MoneyApp.Server.Data;

namespace MoneyApp.Server.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DataContext _context;

    public ExpenseRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Expense>> GetAllExpneses()
    {
        return await _context.Expenses.Include(x => x.ExpenseCategory).ToListAsync();
    }

    public async Task<Expense> GetExpenseById(int id)
    {
        return await _context.Expenses.Include(x => x.ExpenseCategory).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExpense(Expense expense)
    {
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExpense(int id)
    {
        var expense = await GetExpenseById(id);
        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
    }
}
