using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MoneyApp.Client.Services.IncomeCategoryService;

public class IncomeCategoryService : IIncomeCategoryService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public IncomeCategoryService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<IncomeCategoryDTO> IncomeCategories { get; set; } = new List<IncomeCategoryDTO>();

    public async Task GetIncomeCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<List<IncomeCategoryDTO>>("api/incomecategory");

        if (result != null)
        {
            IncomeCategories = result;
        }
    }

    public async Task<IncomeCategoryDTO> GetIncomeCategoryById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<IncomeCategoryDTO>($"api/incomecategory/{id}");

        if (result != null)
        {
            return result;
        }
        else
        {
            throw new Exception("Income category not found.");
        }
    }

    public async Task CreateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO)
    {
        var result = await _httpClient.PostAsJsonAsync("api/incomecategory", incomeCategoryDTO);

        await SetIncomeCategory(result);
    }

    public async Task UpdateIncomeCategory(IncomeCategoryDTO incomeCategoryDTO)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/incomecategory/{incomeCategoryDTO.Id}", incomeCategoryDTO);

        await SetIncomeCategory(result);
    }

    public async Task DeleteIncomeCategory(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/incomecategory/{id}");

        await SetIncomeCategory(result);
    }

    private async Task SetIncomeCategory(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<IncomeCategoryDTO>();

        _navigationManager.NavigateTo("incomecategories");
    }
}
