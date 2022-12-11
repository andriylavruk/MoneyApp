global using Microsoft.EntityFrameworkCore;
global using MoneyApp.Server.Repositories.Interfaces;
global using MoneyApp.Server.Repositories;
global using MoneyApp.Shared.Models;
global using MoneyApp.Shared.DTO;
global using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using MoneyApp.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
