using MoneyApp.Shared.Models;

namespace MoneyApp.Shared.DTO;

public class ExpenseDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public ExpenseCategory? ExpenseCategory { get; set; }
    public int ExpenseCategoryId { get; set; }
}
