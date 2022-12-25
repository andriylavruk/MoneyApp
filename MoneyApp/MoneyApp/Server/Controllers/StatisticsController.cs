using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StatisticsController : ControllerBase
{
    public readonly IStatisticsRepository _statisticsRepository;

    public StatisticsController(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<StatisticsDTO>> GetStatistics()
    {
        var statisticsDTO = new StatisticsDTO()
        {
            TotalExpense = _statisticsRepository.TotalExpense(),
            CurrentYearExpense = _statisticsRepository.CurrentYearExpense(),
            CurrentMonthExpense = _statisticsRepository.CurrentMonthExpense(),

            TotalIncome = _statisticsRepository.TotalIncome(),
            CurrentYearIncome = _statisticsRepository.CurrentYearIncome(),
            CurrentMonthIncome = _statisticsRepository.CurrentMonthIncome()
        };

        return Ok(statisticsDTO);
    }
}
