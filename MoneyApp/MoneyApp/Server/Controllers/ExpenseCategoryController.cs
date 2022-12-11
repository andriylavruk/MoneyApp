using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;

    public ExpenseCategoryController(IExpenseCategoryRepository expenseCategoryRepository)
    {
        _expenseCategoryRepository = expenseCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseCategory>>> GetAllExpenseCategories()
    {
        var expenseCategories = await _expenseCategoryRepository.GetAllExpneseCategories();
        return Ok(expenseCategories);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ExpenseCategory>> GetExpenseCategoryById(int id)
    {
        var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);
        
        if (expenseCategory == null)
        {
            return NotFound();
        }

        return Ok(expenseCategory);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseCategory>> CreateExpenseCategory(ExpenseCategory expenseCategory)
    {
        await _expenseCategoryRepository.CreateExpenseCategory(expenseCategory);

        return Ok(expenseCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseCategory>> UpdateExpenseCategory(int id, ExpenseCategory expenseCategory)
    {
        var dbExpenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);
        
        if (dbExpenseCategory == null)
        {
            return NotFound();
        }
        
        dbExpenseCategory.CategoryName= expenseCategory.CategoryName;

        await _expenseCategoryRepository.UpdateExpenseCategory(dbExpenseCategory);

        return Ok(dbExpenseCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseCategory>> DeleteExpenseCategory(int id)
    {
        var dbExpenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);
        
        if (dbExpenseCategory == null)
        {
            return NotFound();
        }

        await _expenseCategoryRepository.DeleteExpenseCategory(id);

        return Ok(dbExpenseCategory);
    }
}
