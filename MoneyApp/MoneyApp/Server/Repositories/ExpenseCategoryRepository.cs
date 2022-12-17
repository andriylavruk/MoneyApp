using Microsoft.EntityFrameworkCore;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Repositories;

public class ExpenseCategoryRepository : IExpenseCategoryRepository
{
    private readonly DataContext _context;
    private readonly IUserRepository _userRepository;

    public ExpenseCategoryRepository(DataContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<ExpenseCategory>> GetAllExpneseCategories()
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.ExpenseCategories
            .Where(x => x.UserId == currentUser)
            .ToListAsync();
    }

    public async Task<ExpenseCategory> GetExpenseCategoryById(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.ExpenseCategories
            .Where(x => x.UserId == currentUser)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateExpenseCategory(ExpenseCategory expenseCategory)
    {
        expenseCategory.UserId = _userRepository.GetCurrentUser();
        _context.ExpenseCategories.Add(expenseCategory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExpenseCategory(ExpenseCategory expenseCategory)
    {
        var currentUser = _userRepository.GetCurrentUser();

        if (expenseCategory.UserId == currentUser)
        {
            _context.ExpenseCategories.Update(expenseCategory);
            await _context.SaveChangesAsync();
        }   
    }

    public async Task DeleteExpenseCategory(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var expenseCategory = await GetExpenseCategoryById(id);

        if (expenseCategory.UserId == currentUser)
        {
            _context.ExpenseCategories.Remove(expenseCategory);
            await _context.SaveChangesAsync();
        }
    }
}
