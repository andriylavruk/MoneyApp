using Microsoft.EntityFrameworkCore;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Repositories;

public class ExpenseCategoryRepository : IExpenseCategoryRepository
{
    private readonly DataContext _context;

    public ExpenseCategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExpenseCategory>> GetAllExpneseCategories()
    {
        return await _context.ExpenseCategories.ToListAsync();
    }

    public async Task<ExpenseCategory> GetExpenseCategoryById(int id)
    {
        return await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateExpenseCategory(ExpenseCategory expenseCategory)
    {
        _context.ExpenseCategories.Add(expenseCategory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExpenseCategory(ExpenseCategory expenseCategory)
    {
        _context.ExpenseCategories.Update(expenseCategory);
        await _context.SaveChangesAsync();        
    }

    public async Task DeleteExpenseCategory(int id)
    {
        var expenseCategory = await GetExpenseCategoryById(id);
        _context.ExpenseCategories.Remove(expenseCategory);
        await _context.SaveChangesAsync();
    }
}
