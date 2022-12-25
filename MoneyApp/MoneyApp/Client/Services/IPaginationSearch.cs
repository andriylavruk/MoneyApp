namespace MoneyApp.Client.Services;

public interface IPaginationSearch
{
    int TotalPageQuantity { get; set; }
    int CurrentPage { get; set; }
    string SearchFilter { get; set; }

    Task GetAllItems(int page = 1, int quantityPerPage = 10);
}
