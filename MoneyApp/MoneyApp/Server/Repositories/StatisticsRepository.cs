namespace MoneyApp.Server.Repositories;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IIncomeRepository _incomeRepository;

    public StatisticsRepository(IExpenseRepository expenseRepository, IIncomeRepository incomeRepository)
    {
        _expenseRepository = expenseRepository;
        _incomeRepository = incomeRepository;
    }

    public decimal TotalExpense()
    {
        return _expenseRepository.GetAllExpneses().Sum(x => x.Amount);
    }

    public decimal CurrentYearExpense()
    {
        return _expenseRepository
            .GetAllExpneses()
            .Where(x => x.DateCreated.Year == DateTime.Now.Year)
            .Sum(x => x.Amount);
    }

    public decimal CurrentMonthExpense()
    {
        return _expenseRepository
            .GetAllExpneses()
            .Where(x => x.DateCreated.Month == DateTime.Now.Month)
            .Sum(x => x.Amount);
    }

    public decimal TotalIncome()
    {
        return _incomeRepository.GetAllIncomes().Sum(x => x.Amount);
    }

    public decimal CurrentYearIncome()
    {
        return _incomeRepository
            .GetAllIncomes()
            .Where(x => x.DateCreated.Year == DateTime.Now.Year)
            .Sum(x => x.Amount);
    }

    public decimal CurrentMonthIncome()
    {
        return _incomeRepository
            .GetAllIncomes()
            .Where(x => x.DateCreated.Month == DateTime.Now.Month)
            .Sum(x => x.Amount);
    }
}
