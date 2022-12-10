﻿using Microsoft.AspNetCore.Components;
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

    public List<Expense>? Expenses { get; set; }

    public async Task GetExpenses()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Expense>>("api/expense");

        if (result != null)
        {
            Expenses = result;
        }
    }

    public async Task<Expense> GetExpenseById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<Expense>($"api/expense/{id}");

        if (result != null)
        {
            return result;
        }
        else
        {
            throw new Exception("Expense not found.");
        }
    }

    public async Task CreateExpense(Expense expense)
    {
        var result = await _httpClient.PostAsJsonAsync("api/expense", expense);

        await SetExpense(result);
    }

    public async Task UpdateExpense(Expense expense)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/expense/{expense.Id}", expense);

        await SetExpense(result);
    }

    public async Task DeleteExpense(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/expense/{id}");

        await SetExpense(result);
    }

    private async Task SetExpense(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<Expense>();

        _navigationManager.NavigateTo("expenses");
    }
}