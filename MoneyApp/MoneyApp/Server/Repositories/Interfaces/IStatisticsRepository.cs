namespace MoneyApp.Server.Repositories.Interfaces;

public interface IStatisticsRepository
{
    decimal TotalExpense();
    decimal CurrentYearExpense();
    decimal CurrentMonthExpense();
    
    decimal TotalIncome();
    decimal CurrentYearIncome();
    decimal CurrentMonthIncome();
}
