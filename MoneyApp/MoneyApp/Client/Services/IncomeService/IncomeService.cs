using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace MoneyApp.Client.Services.IncomeService;

public class IncomeService : IIncomeService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public int TotalPageQuantity { get; set; }
    public int CurrentPage { get; set; } = 1;

    public IncomeService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<IncomeDTO>? Incomes { get; set; }

    public async Task GetAllItems(int page = 1, int quantityPerPage = 10)
    {
        var httpResponse = await _httpClient.GetAsync($"api/income?page={page}&quantityPerPage={quantityPerPage}");

        if (httpResponse.IsSuccessStatusCode)
        {
            TotalPageQuantity = int.Parse(httpResponse.Headers.GetValues("pagesQuantity").FirstOrDefault());
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<IncomeDTO>>(responseString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (result != null)
            {
                Incomes = result;
            }
        }
    }

    public async Task<IncomeDTO> GetIncomeById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<IncomeDTO>($"api/income/{id}");

        if (result != null)
        {
            return result;
        }
        else
        {
            throw new Exception("Income not found.");
        }
    }

    public async Task CreateIncome(IncomeDTO incomeDTO)
    {
        var result = await _httpClient.PostAsJsonAsync("api/income", incomeDTO);

        await SetIncome(result);
    }

    public async Task UpdateIncome(IncomeDTO incomeDTO)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/income/{incomeDTO.Id}", incomeDTO);

        await SetIncome(result);
    }

    public async Task DeleteIncome(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/income/{id}");

        await SetIncome(result);
    }

    private async Task SetIncome(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<IncomeDTO>();

        _navigationManager.NavigateTo("incomes");
    }
}
