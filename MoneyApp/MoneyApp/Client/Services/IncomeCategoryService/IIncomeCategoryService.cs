namespace MoneyApp.Client.Services.IncomeCategoryService;

public interface IIncomeCategoryService : IPaginationSearch
{
    List<IncomeCategoryDTO> IncomeCategories { get; set; }

    Task<IncomeCategoryDTO> GetIncomeCategoryById(int id);
    Task CreateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO);
    Task UpdateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO);
    Task DeleteIncomeCategory(int id);
}
