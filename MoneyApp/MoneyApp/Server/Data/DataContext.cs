
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
}
