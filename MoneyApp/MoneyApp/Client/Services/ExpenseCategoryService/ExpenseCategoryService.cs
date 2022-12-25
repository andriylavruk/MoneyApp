using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace MoneyApp.Client.Services.ExpenseCategoryService;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public int TotalPageQuantity { get; set; }
    public int CurrentPage { get; set; } = 1;
    public string SearchFilter { get; set; } = string.Empty;

    public ExpenseCategoryService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<ExpenseCategoryDTO> ExpenseCategories { get; set; } = new List<ExpenseCategoryDTO>();

    public async Task GetAllItems(int page = 1, int quantityPerPage = 10)
    {
        var httpResponse = await _httpClient.GetAsync($"api/expensecategory?page={page}&quantityPerPage={quantityPerPage}&searchFilter={SearchFilter}");

        if(httpResponse.IsSuccessStatusCode)
        {
            TotalPageQuantity = int.Parse(httpResponse.Headers.GetValues("pagesQuantity").FirstOrDefault());
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ExpenseCategoryDTO>>(responseString, 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (result != null)
            {
                ExpenseCategories = result;
            }
        }
    }

    public async Task<ExpenseCategoryDTO> GetExpenseCategoryById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<ExpenseCategoryDTO>($"api/expensecategory/{id}");

        if (result != null)
        {
            return result;
        }
        else
        {
            throw new Exception("Expense category not found.");
        }
    }

    public async Task CreateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO)
    {
        var result = await _httpClient.PostAsJsonAsync("api/expensecategory", expenseCategoryDTO);

        await SetExpenseCategory(result);
    }

    public async Task UpdateExpenseCategory(ExpenseCategoryDTO expenseCategoryDTO)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/expensecategory/{expenseCategoryDTO.Id}", expenseCategoryDTO);

        await SetExpenseCategory(result);
    }

    public async Task DeleteExpenseCategory(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/expensecategory/{id}");
        
        await SetExpenseCategory(result);
    }

    private async Task SetExpenseCategory(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<ExpenseCategoryDTO>();

        _navigationManager.NavigateTo("expensecategories");
    }
}
