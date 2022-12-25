global using MoneyApp.Client.Services.ExpenseCategoryService;
global using MoneyApp.Client.Services.IncomeCategoryService;
global using MoneyApp.Client.Services.ExpenseService;
global using MoneyApp.Client.Services.IncomeService;
global using MoneyApp.Client.Services.StatisticsService;
global using MoneyApp.Shared;
global using MoneyApp.Shared.Models;
global using MoneyApp.Shared.DTO;
global using System.Net.Http.Json;
global using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoneyApp.Client;
using Microsoft.AspNetCore.Components.Authorization;
using MoneyApp.Client.Providers;
using MoneyApp.Client.Services.StatisticsService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
builder.Services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();

builder.Services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
