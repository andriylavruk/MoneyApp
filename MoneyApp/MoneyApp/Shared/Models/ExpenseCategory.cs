namespace MoneyApp.Shared.Models;

public class ExpenseCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
