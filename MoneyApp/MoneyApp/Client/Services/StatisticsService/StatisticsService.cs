namespace MoneyApp.Client.Services.StatisticsService;

public class StatisticsService : IStatisticsService
{
    private readonly HttpClient _httpClient;

    public StatisticsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public StatisticsDTO? Statistics { get; set ; }

    public async Task GetStatistics()
    {
        var result = await _httpClient.GetFromJsonAsync<StatisticsDTO>($"api/statistics");

        if (result != null)
        {
            Statistics = result;
        }
    }
}
