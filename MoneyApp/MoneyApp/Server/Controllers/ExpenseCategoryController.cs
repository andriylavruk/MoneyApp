using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    public static List<ExpenseCategory> expenseCategories = new List<ExpenseCategory>
    {
        new ExpenseCategory
        {
            Id = Guid.NewGuid(),
            CategoryName = "Food"
        },
        new ExpenseCategory
        {
            Id = Guid.NewGuid(),
            CategoryName = "House"
        }
    };

    [HttpGet]
    public async Task<ActionResult<List<ExpenseCategory>>> GetExpenseCategories()
    {
        return Ok(expenseCategories);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ExpenseCategory>> GetExpenseCategoryById(Guid id)
    {
        var expenseCategory = expenseCategories.FirstOrDefault(x => x.Id == id);
        
        if (expenseCategory == null)
        {
            return NotFound("Sorry, no expense category.");
        }

        return Ok(expenseCategory);
    }
}
