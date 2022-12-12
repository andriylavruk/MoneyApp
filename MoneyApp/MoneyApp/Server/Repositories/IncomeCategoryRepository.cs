using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Repositories;

public class IncomeCategoryRepository : IIncomeCategoryRepository
{
    private readonly DataContext _context;

    public IncomeCategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IncomeCategory>> GetAllIncomeCategories()
    {
        return await _context.IncomeCategories.ToListAsync();
    }

    public async Task<IncomeCategory> GetIncomeCategoryById(int id)
    {
        return await _context.IncomeCategories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateIncomeCategory(IncomeCategory incomeCategory)
    {
        _context.IncomeCategories.Add(incomeCategory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIncomeCategory(IncomeCategory incomeCategory)
    {
        _context.IncomeCategories.Update(incomeCategory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIncomeCategory(int id)
    {
        var incomeCategory = await GetIncomeCategoryById(id);
        _context.IncomeCategories.Remove(incomeCategory);
        await _context.SaveChangesAsync();
    }
}
