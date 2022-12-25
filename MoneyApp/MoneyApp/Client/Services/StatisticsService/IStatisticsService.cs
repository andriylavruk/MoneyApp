namespace MoneyApp.Client.Services.StatisticsService;

public interface IStatisticsService
{
    StatisticsDTO? Statistics { get; set; }

    Task GetStatistics();
}
