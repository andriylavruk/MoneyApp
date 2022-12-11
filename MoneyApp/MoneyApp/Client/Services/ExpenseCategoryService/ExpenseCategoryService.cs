using Microsoft.AspNetCore.Components;
using MoneyApp.Shared.Models;
using System.Net.Http.Json;

namespace MoneyApp.Client.Services.ExpenseCategoryService;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public ExpenseCategoryService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<ExpenseCategoryDTO> ExpenseCategories { get; set; } = new List<ExpenseCategoryDTO>();

    public async Task GetExpenseCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ExpenseCategoryDTO>>("api/expensecategory");

        if (result != null)
        {
            ExpenseCategories = result;
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
