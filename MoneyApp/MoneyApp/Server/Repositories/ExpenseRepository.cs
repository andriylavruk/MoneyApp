using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DataContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;


    public ExpenseRepository(DataContext context, 
        IUserRepository userRepository, 
        IExpenseCategoryRepository expenseCategoryRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _expenseCategoryRepository = expenseCategoryRepository;
    }

    public async Task<IEnumerable<Expense>> GetAllExpneses()
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.Expenses
            .Include(x => x.ExpenseCategory)
            .Where(x => x.ExpenseCategory.UserId == currentUser)
            .ToListAsync();
    }

    public async Task<Expense> GetExpenseById(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.Expenses
            .Include(x => x.ExpenseCategory)
            .Where(x => x.ExpenseCategory.UserId == currentUser)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateExpense(Expense expense)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(expense.ExpenseCategoryId);

        if (expenseCategory.UserId == currentUser)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateExpense(Expense expense)
    {
        var currentUser = _userRepository.GetCurrentUser();

        if (expense.ExpenseCategory.UserId == currentUser)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteExpense(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var expense = await GetExpenseById(id);

        if (expense.ExpenseCategory.UserId == currentUser)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }  
    }
}
