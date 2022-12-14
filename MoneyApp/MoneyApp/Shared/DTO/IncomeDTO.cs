using MoneyApp.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyApp.Shared.DTO;

public class IncomeDTO
{
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Must be no more than {1} characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 9999999999999999.99, ErrorMessage = "Please enter a value bigger than {1}")]
    public decimal Amount { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public IncomeCategory? IncomeCategory { get; set; }

    [Required]
    public int? IncomeCategoryId { get; set; }
}
