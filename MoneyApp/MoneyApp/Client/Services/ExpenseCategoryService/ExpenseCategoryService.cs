using MoneyApp.Shared.Models;
using System.Net.Http.Json;

namespace MoneyApp.Client.Services.ExpenseCategoryService
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly HttpClient _httpClient;

        public ExpenseCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
    }
}
