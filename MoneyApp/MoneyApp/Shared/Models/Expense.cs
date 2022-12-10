using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyApp.Shared.Models;

public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public ExpenseCategory? ExpenseCategory { get; set; }
    public int ExpenseCategoryId { get; set; }
}
