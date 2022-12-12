using MoneyApp.Server.Data;

namespace MoneyApp.Server.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly DataContext _context;

    public IncomeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Income>> GetAllIncomes()
    {
        return await _context.Incomes.Include(x => x.IncomeCategory).ToListAsync();
    }

    public async Task<Income> GetIncomeById(int id)
    {
        return await _context.Incomes.Include(x => x.IncomeCategory).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateIncome(Income income)
    {
        _context.Incomes.Add(income);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIncome(Income income)
    {
        _context.Incomes.Update(income);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIncome(int id)
    {
        var income = await GetIncomeById(id);
        _context.Incomes.Remove(income);
        await _context.SaveChangesAsync();
    }
}
