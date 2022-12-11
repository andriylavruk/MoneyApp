using Microsoft.AspNetCore.Components;
using MoneyApp.Shared.Models;
using System.Net.Http.Json;

namespace MoneyApp.Client.Services.ExpenseService;

public class ExpenseService : IExpenseService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public ExpenseService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<ExpenseDTO>? Expenses { get; set; }

    public async Task GetExpenses()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ExpenseDTO>>("api/expense");

        if (result != null)
        {
            Expenses = result;
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
