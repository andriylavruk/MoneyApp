using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Server.Helpers;
using MoneyApp.Shared.DTO;

namespace MoneyApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly IMapper _mapper;

        public IncomeCategoryController(IIncomeCategoryRepository incomeCategoryRepository, IMapper mapper)
        {
            _incomeCategoryRepository = incomeCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeCategoryDTO>>> GetAllIncomeCategories([FromQuery] PaginationDTO pagination)
        {
            var queryable = _incomeCategoryRepository.GetAllIncomeCategories().AsQueryable();
            await HttpContext.InsertPaginationParameterInResoponse(queryable, pagination.QuantityPerPage);
            var incomeCategories = await queryable.Paginate(pagination).ToListAsync();
            var mappedIncomeCategories = _mapper.Map<IEnumerable<IncomeCategoryDTO>>(incomeCategories);

            return Ok(mappedIncomeCategories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IncomeCategoryDTO>> GetIncomeCategoryById(int id)
        {
            var incomeCategory = await _incomeCategoryRepository.GetIncomeCategoryById(id);

            if (incomeCategory == null)
            {
                return NotFound();
            }

            var mappedIncomeCategory = _mapper.Map<IncomeCategoryDTO>(incomeCategory);

            return Ok(mappedIncomeCategory);
        }

        [HttpPost]
        public async Task<ActionResult<IncomeCategoryDTO>> CreateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO)
        {
            var incomeCategory = _mapper.Map<IncomeCategory>(incomeCategoryDTO);
            await _incomeCategoryRepository.CreateIncomeCategory(incomeCategory);

            return Ok(incomeCategoryDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IncomeCategoryDTO>> UpdateIncomeCategory(int id, IncomeCategoryDTO incomeCategoryDTO)
        {
            var mapperIncomeCategory = _mapper.Map<IncomeCategory>(incomeCategoryDTO);
            await _incomeCategoryRepository.UpdateIncomeCategory(mapperIncomeCategory);

            return Ok(mapperIncomeCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IncomeCategoryDTO>> DeleteIncomeCategory(int id)
        {
            var dbIncomeCategory = await _incomeCategoryRepository.GetIncomeCategoryById(id);

            if (dbIncomeCategory == null)
            {
                return NotFound();
            }

            var mappperIncomeCategory = _mapper.Map<IncomeCategory>(dbIncomeCategory);
            await _incomeCategoryRepository.DeleteIncomeCategory(id);

            return Ok(mappperIncomeCategory);
        }
    }
}
