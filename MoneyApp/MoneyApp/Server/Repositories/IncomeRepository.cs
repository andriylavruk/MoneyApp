using MoneyApp.Server.Data;

namespace MoneyApp.Server.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly DataContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IIncomeCategoryRepository _incomeCategoryRepository;

    public IncomeRepository(DataContext context, 
        IUserRepository userRepository, 
        IIncomeCategoryRepository incomeCategoryRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _incomeCategoryRepository = incomeCategoryRepository;
    }

    public IQueryable<Income> GetAllIncomes()
    {
        var currentUser = _userRepository.GetCurrentUser();
        return  _context.Incomes
            .Include(x => x.IncomeCategory)
            .Where(x => x.IncomeCategory.UserId == currentUser)
            .OrderByDescending(x => x.DateCreated);
    }

    public async Task<Income> GetIncomeById(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        return await _context.Incomes
            .Include(x => x.IncomeCategory)
            .Where(x => x.IncomeCategory.UserId == currentUser)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateIncome(Income income)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var incomeCategory = await _incomeCategoryRepository.GetIncomeCategoryById(income.IncomeCategoryId);

        if (incomeCategory.UserId == currentUser)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
        }   
    }

    public async Task UpdateIncome(Income income)
    {
        var currentUser = _userRepository.GetCurrentUser();

        if (income.IncomeCategory.UserId == currentUser)
        {
            _context.Incomes.Update(income);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteIncome(int id)
    {
        var currentUser = _userRepository.GetCurrentUser();
        var income = await GetIncomeById(id);


        if (income.IncomeCategory.UserId == currentUser)
        {
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }
    }
}
