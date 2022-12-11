using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseController(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetAllExpenses()
    {
        var expenses = await _expenseRepository.GetAllExpneses();
        return Ok(expenses);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Expense>> GetExpenseCategoryById(int id)
    {
        var expense = await _expenseRepository.GetExpenseById(id);

        if (expense == null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpenseCategory(Expense expense)
    {
        expense.ExpenseCategory = null;
        await _expenseRepository.CreateExpense(expense);

        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Expense>> UpdateExpenseCategory(int id, Expense expense)
    {
        var dbExpense = await _expenseRepository.GetExpenseById(id);

        if (dbExpense == null)
        {
            return NotFound();
        }

        dbExpense.Description = expense.Description;
        dbExpense.Amount = expense.Amount;
        dbExpense.DateCreated= expense.DateCreated;
        dbExpense.ExpenseCategoryId = expense.ExpenseCategoryId;

        await _expenseRepository.UpdateExpense(dbExpense);

        return Ok(dbExpense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Expense>> DeleteExpenseCategory(int id)
    {
        var dbExpense = await _expenseRepository.GetExpenseById(id);

        if (dbExpense == null)
        {
            return NotFound();
        }

        await _expenseRepository.DeleteExpense(id);

        return Ok(dbExpense);
    }
}
