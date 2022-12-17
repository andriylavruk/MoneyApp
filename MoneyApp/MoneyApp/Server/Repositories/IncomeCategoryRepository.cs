using MoneyApp.Server.Data;
using MoneyApp.Shared.Models;

namespace MoneyApp.Server.Repositories;

public class IncomeCategoryRepository : IIncomeCategoryRepository
{
    private readonly DataContext _context;
    private readonly IUserRepository _userRepository;


    public IncomeCategoryRepository(DataContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<IncomeCategory>> GetAllIncomeCategories()
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.IncomeCategories
            .Where(x => x.UserId == currentUser)
            .ToListAsync();
    }

    public async Task<IncomeCategory> GetIncomeCategoryById(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.IncomeCategories
            .Where(x => x.UserId == currentUser)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateIncomeCategory(IncomeCategory incomeCategory)
    {
        incomeCategory.UserId = _userRepository.GetCurrentUser();
        _context.IncomeCategories.Add(incomeCategory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIncomeCategory(IncomeCategory incomeCategory)
    {
        var currentUser = _userRepository.GetCurrentUser();

        if (incomeCategory.UserId == currentUser)
        {
            _context.IncomeCategories.Update(incomeCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteIncomeCategory(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var incomeCategory = await GetIncomeCategoryById(id);

        if (incomeCategory.UserId == currentUser)
        {
            _context.IncomeCategories.Remove(incomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}
