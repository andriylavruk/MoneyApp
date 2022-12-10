using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    private readonly DataContext _context;

    public ExpenseCategoryController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExpenseCategory>>> GetAllExpenseCategories()
    {
        var expenseCategories = await _context.ExpenseCategories.ToListAsync();
        return Ok(expenseCategories);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ExpenseCategory>> GetExpenseCategoryById(Guid id)
    {
        var expenseCategory = await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        
        if (expenseCategory == null)
        {
            return NotFound("Sorry, no expense category.");
        }

        return Ok(expenseCategory);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseCategory>> CreateExpenseCategory(ExpenseCategory expenseCategory)
    {
        _context.ExpenseCategories.Add(expenseCategory);
        await _context.SaveChangesAsync();

        return Ok(expenseCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseCategory>> UpdateExpenseCategory(Guid id, ExpenseCategory expenseCategory)
    {
        var dbExpenseCategory = await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);
        
        if (dbExpenseCategory == null)
        {
            return NotFound("Sorry, no expense category");
        }
        
        dbExpenseCategory.CategoryName = expenseCategory.CategoryName;

        await _context.SaveChangesAsync();

        return Ok(dbExpenseCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseCategory>> DeleteExpenseCategory(Guid id)
    {
        var dbExpenseCategory = await _context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == id);

        if (dbExpenseCategory == null)
        {
            return NotFound("Sorry, no expense category");
        }

        _context.ExpenseCategories.Remove(dbExpenseCategory);

        await _context.SaveChangesAsync();

        return Ok(dbExpenseCategory);
    }
}
