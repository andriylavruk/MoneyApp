using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Shared.DTO;

public class IncomeCategoryDTO
{
    public int Id { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Must be at least {1} characters long")]
    [MaxLength(100, ErrorMessage = "Must be no more than {1} characters.")]
    public string CategoryName { get; set; } = string.Empty;
}
