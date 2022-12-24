using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Helpers;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
    public async Task<ActionResult<IEnumerable<ExpenseCategoryDTO>>> GetAllExpenseCategories([FromQuery] PaginationDTO pagination)
    {
        var queryable = _expenseCategoryRepository.GetAllExpneseCategories().AsQueryable();
        await HttpContext.InsertPaginationParameterInResoponse(queryable, pagination.QuantityPerPage);
        var expenseCategories = await queryable.Paginate(pagination).ToListAsync();
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
        var mapperExpenseCategory = _mapper.Map<ExpenseCategory>(expenseCategoryDTO);
        await _expenseCategoryRepository.UpdateExpenseCategory(mapperExpenseCategory);

        return Ok(mapperExpenseCategory);
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
