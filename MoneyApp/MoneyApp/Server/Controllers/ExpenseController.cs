using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.DTO;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;
    private readonly IMapper _mapper;

    public ExpenseController(IExpenseRepository expenseRepository, 
        IExpenseCategoryRepository expenseCategoryRepository, 
        IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _expenseCategoryRepository = expenseCategoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetAllExpenses()
    {
        var expenses = await _expenseRepository.GetAllExpneses();
        var mappedExpenses = _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        return Ok(mappedExpenses);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ExpenseDTO>> GetExpenseCategoryById(int id)
    {
        var expense = await _expenseRepository.GetExpenseById(id);

        if (expense == null)
        {
            return NotFound();
        }

        var mappedExpense = _mapper.Map<ExpenseDTO>(expense);

        return Ok(mappedExpense);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDTO>> CreateExpenseCategory(ExpenseDTO expenseDTO)
    {
        expenseDTO.ExpenseCategory = null;
        var expense = _mapper.Map<Expense>(expenseDTO);
        await _expenseRepository.CreateExpense(expense);


        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseDTO>> UpdateExpenseCategory(int id, ExpenseDTO expenseDTO)
    {
        var mapperExpense = _mapper.Map<Expense>(expenseDTO);
        var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(mapperExpense.ExpenseCategoryId);
        mapperExpense.ExpenseCategory = expenseCategory;
        await _expenseRepository.UpdateExpense(mapperExpense);

        return Ok(mapperExpense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseDTO>> DeleteExpenseCategory(int id)
    {
        var dbExpense = await _expenseRepository.GetExpenseById(id);

        if (dbExpense == null)
        {
            return NotFound();
        }

        var mappperExpense = _mapper.Map<Expense>(dbExpense);
        await _expenseRepository.DeleteExpense(id);

        return Ok(mappperExpense);
    }
}
