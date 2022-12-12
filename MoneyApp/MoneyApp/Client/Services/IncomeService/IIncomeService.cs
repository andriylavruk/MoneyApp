namespace MoneyApp.Client.Services.IncomeService;

public interface IIncomeService
{
    List<IncomeDTO>? Incomes { get; set; }

    Task GetIncomes();

    Task<IncomeDTO> GetIncomeById(int id);
    Task CreateIncome(IncomeDTO incomeDTO);
    Task UpdateIncome(IncomeDTO incomeDTO);
    Task DeleteIncome(int id);
}
