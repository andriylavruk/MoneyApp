global using MoneyApp.Client.Services.ExpenseCategoryService;
global using MoneyApp.Client.Services.IncomeCategoryService;
global using MoneyApp.Client.Services.ExpenseService;
global using MoneyApp.Client.Services.IncomeService;
global using MoneyApp.Shared;
global using MoneyApp.Shared.Models;
global using MoneyApp.Shared.DTO;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoneyApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
builder.Services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();

await builder.Build().RunAsync();
