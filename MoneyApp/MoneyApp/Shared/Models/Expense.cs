namespace MoneyApp.Shared.Models;

public class Expense
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; }
    public ExpenseCategory? ExpenseCategory { get; set; }
    public Guid ExpenseCategoryId { get; set; }
}
