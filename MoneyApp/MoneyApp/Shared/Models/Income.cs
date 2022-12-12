using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyApp.Shared.Models;

public class Income
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public IncomeCategory? IncomeCategory { get; set; }
    public int IncomeCategoryId { get; set; }
}
