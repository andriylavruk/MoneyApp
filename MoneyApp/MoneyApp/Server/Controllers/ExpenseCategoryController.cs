/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Data;
using MoneyApp.Shared.DTO;
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
    public async Task<ActionResult<IEnumerable<ExpenseCategoryDTO>>> GetAllExpenseCategories()
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
}*/


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Client.Pages.ExpenseCategoryPages;
using MoneyApp.Server.Data;
using MoneyApp.Shared.DTO;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;
    private readonly IMapper _mapper;

    public ExpenseCategoryController(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
    {
        _expenseCategoryRepository = expenseCategoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseCategoryDTO>>> GetAllExpenseCategories()
    {
        var expenseCategories = await _expenseCategoryRepository.GetAllExpneseCategories();
        var mappedExpenseCategories = _mapper.Map<IEnumerable<ExpenseCategoryDTO>>(expenseCategories);

        return Ok(mappedExpenseCategories);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ExpenseCategoryDTO>> GetExpenseCategoryById(int id)
    {
        var expenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);

        if (expenseCategory == null)
        {
            return NotFound();
        }

        var mappedExpenseCategory = _mapper.Map<ExpenseCategoryDTO>(expenseCategory);

        return Ok(mappedExpenseCategory);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseCategoryDTO>> CreateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO)
    {
        var expenseCategory = _mapper.Map<ExpenseCategory>(expenseCategoryDTO);
        await _expenseCategoryRepository.CreateExpenseCategory(expenseCategory);

        return Ok(expenseCategoryDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseCategoryDTO>> UpdateExpenseCategory(int id, ExpenseCategoryDTO expenseCategoryDTO)
    {
        var dbExpenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);

        if (dbExpenseCategory == null)
        {
            return NotFound();
        }

        var mappperExpenseCategory = _mapper.Map<ExpenseCategory>(expenseCategoryDTO);
        await _expenseCategoryRepository.UpdateExpenseCategory(_mapper.Map(mappperExpenseCategory, dbExpenseCategory));

        return Ok(mappperExpenseCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseCategoryDTO>> DeleteExpenseCategory(int id)
    {
        var dbExpenseCategory = await _expenseCategoryRepository.GetExpenseCategoryById(id);

        if (dbExpenseCategory == null)
        {
            return NotFound();
        }

        var mappperExpenseCategory = _mapper.Map<ExpenseCategory>(dbExpenseCategory);
        await _expenseCategoryRepository.DeleteExpenseCategory(id);

        return Ok(mappperExpenseCategory);
    }
}
