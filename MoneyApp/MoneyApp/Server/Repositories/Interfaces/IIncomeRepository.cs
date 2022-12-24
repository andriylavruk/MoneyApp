namespace MoneyApp.Server.Repositories.Interfaces;

public interface IIncomeRepository
{
    IQueryable<Income> GetAllIncomes();
    Task<Income> GetIncomeById(int id);
    Task CreateIncome(Income income);
    Task UpdateIncome(Income income);
    Task DeleteIncome(int id);
}
