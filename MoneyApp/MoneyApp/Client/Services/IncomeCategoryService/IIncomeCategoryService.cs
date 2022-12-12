namespace MoneyApp.Client.Services.IncomeCategoryService;

public interface IIncomeCategoryService
{
    List<IncomeCategoryDTO> IncomeCategories { get; set; }

    Task GetIncomeCategories();

    Task<IncomeCategoryDTO> GetIncomeCategoryById(int id);
    Task CreateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO);
    Task UpdateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO);
    Task DeleteIncomeCategory(int id);
}
