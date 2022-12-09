
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCategory>().HasData(
            new ExpenseCategory
            {
                Id = Guid.NewGuid(),
                CategoryName = "Food"
            },
            new ExpenseCategory
            {
                Id = Guid.NewGuid(),
                CategoryName = "House"
            }
        );
    }

    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
}
