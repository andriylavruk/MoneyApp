using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoneyApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeRepository incomeRepository, 
            IIncomeCategoryRepository incomeCategoryRepository, 
            IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _incomeCategoryRepository = incomeCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.GetAllIncomes();
            var mappedIncomes = _mapper.Map<IEnumerable<IncomeDTO>>(incomes);
            return Ok(mappedIncomes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IncomeDTO>> GetIncomeCategoryById(int id)
        {
            var income = await _incomeRepository.GetIncomeById(id);

            if (income == null)
            {
                return NotFound();
            }

            var mappedIncome = _mapper.Map<IncomeDTO>(income);

            return Ok(mappedIncome);
        }

        [HttpPost]
        public async Task<ActionResult<IncomeDTO>> CreateIncomeCategory(IncomeDTO incomeDTO)
        {
            incomeDTO.IncomeCategory = null;
            var income = _mapper.Map<Income>(incomeDTO);
            await _incomeRepository.CreateIncome(income);


            return Ok(income);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IncomeDTO>> UpdateIncomeCategory(int id, IncomeDTO incomeDTO)
        {
            var mapperIncome = _mapper.Map<Income>(incomeDTO);
            var incomeCategory = await _incomeCategoryRepository.GetIncomeCategoryById(mapperIncome.IncomeCategoryId);
            mapperIncome.IncomeCategory = incomeCategory;
            await _incomeRepository.UpdateIncome(mapperIncome);

            return Ok(mapperIncome);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IncomeDTO>> DeleteIncomeCategory(int id)
        {
            var dbIncome = await _incomeRepository.GetIncomeById(id);

            if (dbIncome == null)
            {
                return NotFound();
            }

            var mappperIncome = _mapper.Map<Income>(dbIncome);
            await _incomeRepository.DeleteIncome(id);

            return Ok(mappperIncome);
        }
    }
}
