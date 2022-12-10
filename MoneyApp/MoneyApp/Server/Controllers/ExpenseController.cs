using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly DataContext _context;

    public ExpenseController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetAllExpenses()
    {
        var expenses = await _context.Expenses.Include(x => x.ExpenseCategory).ToListAsync();
        return Ok(expenses);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Expense>> GetExpenseCategoryById(int id)
    {
        var expense = await _context.Expenses
            .Include(x => x.ExpenseCategory)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (expense == null)
        {
            return NotFound("Sorry, no expense.");
        }

        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpenseCategory(Expense expense)
    {
        expense.ExpenseCategory = null;
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Expense>> UpdateExpenseCategory(int id, Expense expense)
    {
        var dbExpense = await _context.Expenses
            .Include(x => x.ExpenseCategory)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dbExpense == null)
        {
            return NotFound("Sorry, no expense.");
        }

        dbExpense.Description = expense.Description;
        dbExpense.Amount = expense.Amount;
        dbExpense.DateCreated= expense.DateCreated;
        dbExpense.ExpenseCategoryId = expense.ExpenseCategoryId;

        await _context.SaveChangesAsync();

        return Ok(dbExpense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Expense>> DeleteExpenseCategory(int id)
    {
        var dbExpense = await _context.Expenses
            .Include(x => x.ExpenseCategory)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dbExpense == null)
        {
            return NotFound("Sorry, no expense.");
        }

        _context.Expenses.Remove(dbExpense);

        await _context.SaveChangesAsync();

        return Ok(dbExpense);
    }
}
