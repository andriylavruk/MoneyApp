namespace MoneyApp.Client.Services;

public interface IPagination
{
    int TotalPageQuantity { get; set; }
    int CurrentPage { get; set; }

    Task GetAllItems(int page = 1, int quantityPerPage = 10);
}
