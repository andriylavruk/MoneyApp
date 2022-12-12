using MoneyApp.Shared.Models;

namespace MoneyApp.Shared.DTO;

public class IncomeDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public IncomeCategory? IncomeCategory { get; set; }
    public int IncomeCategoryId { get; set; }
}
