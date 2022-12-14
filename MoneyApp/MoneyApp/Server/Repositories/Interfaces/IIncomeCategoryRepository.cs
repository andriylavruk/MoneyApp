namespace MoneyApp.Server.Repositories.Interfaces;

public interface IIncomeCategoryRepository
{
    IQueryable<IncomeCategory> GetAllIncomeCategories();
    Task<IncomeCategory> GetIncomeCategoryById(int id);
    Task CreateIncomeCategory(IncomeCategory incomeCategory);
    Task UpdateIncomeCategory(IncomeCategory incomeCategory);
    Task DeleteIncomeCategory(int id);
}
