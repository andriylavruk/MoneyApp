namespace MoneyApp.Shared.DTO;

public class StatisticsDTO
{
    public decimal TotalExpense { get; set; }
    public decimal CurrentYearExpense { get; set; }
    public decimal CurrentMonthExpense { get; set; }
           
    public decimal TotalIncome { get; set; }
    public decimal CurrentYearIncome { get; set; }
    public decimal CurrentMonthIncome { get; set; }
}
