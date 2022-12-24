using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace MoneyApp.Client.Services.ExpenseService;

public class ExpenseService : IExpenseService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public int TotalPageQuantity { get; set; }
    public int CurrentPage { get; set; } = 1;

    public ExpenseService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<ExpenseDTO>? Expenses { get; set; }

    public async Task GetAllItems(int page = 1, int quantityPerPage = 10)
    {
        var httpResponse = await _httpClient.GetAsync($"api/expense?page={page}&quantityPerPage={quantityPerPage}");

        if (httpResponse.IsSuccessStatusCode)
        {
            TotalPageQuantity = int.Parse(httpResponse.Headers.GetValues("pagesQuantity").FirstOrDefault());
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ExpenseDTO>>(responseString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (result != null)
            {
                Expenses = result;
            }
        }
    }

    public async Task<ExpenseDTO> GetExpenseById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<ExpenseDTO>($"api/expense/{id}");

        if (result != null)
        {
            return result;
        }
        else
        {
            throw new Exception("Expense not found.");
        }
    }

    public async Task CreateExpense(ExpenseDTO expenseDTO)
    {
        var result = await _httpClient.PostAsJsonAsync("api/expense", expenseDTO);

        await SetExpense(result);
    }

    public async Task UpdateExpense(ExpenseDTO expenseDTO)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/expense/{expenseDTO.Id}", expenseDTO);

        await SetExpense(result);
    }

    public async Task DeleteExpense(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/expense/{id}");

        await SetExpense(result);
    }

    private async Task SetExpense(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<ExpenseDTO>();

        _navigationManager.NavigateTo("expenses");
    }
}
