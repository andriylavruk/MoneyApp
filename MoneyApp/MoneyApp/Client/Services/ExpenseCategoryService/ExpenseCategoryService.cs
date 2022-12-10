using Microsoft.AspNetCore.Components;
using MoneyApp.Shared.Models;
using System.Net.Http.Json;

namespace MoneyApp.Client.Services.ExpenseCategoryService
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ExpenseCategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<ExpenseCategory> ExpenseCategories { get; set; } = new List<ExpenseCategory>();

        public async Task GetExpenseCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ExpenseCategory>>("api/expensecategory");

            if (result != null)
            {
                ExpenseCategories = result;
            }
        }

        public async Task<ExpenseCategory> GetExpenseCategoryById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ExpenseCategory>($"api/expensecategory/{id}");

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Expense category not found.");
            }
        }

        public async Task CreateExpenseCategory(ExpenseCategory expenseCategory)
        {
            var result = await _httpClient.PostAsJsonAsync("api/expensecategory", expenseCategory);
            await SetExpenseCategory(result);
        }

        public async Task UpdateExpenseCategory(ExpenseCategory expenseCategory)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/expensecategory/{expenseCategory.Id}", expenseCategory);

            await SetExpenseCategory(result);
        }

        public async Task DeleteExpenseCategory(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/expensecategory/{id}");
            
            await SetExpenseCategory(result);
        }

        private async Task SetExpenseCategory(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<ExpenseCategory>();

            _navigationManager.NavigateTo("expensecategories");
        }
    }
}
