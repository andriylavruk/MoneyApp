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
    public async Task<ActionResult<List<ExpenseCategory>>> GetExpenseCategories()
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
}
