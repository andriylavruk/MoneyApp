using MoneyApp.Shared.DTO;

namespace MoneyApp.Server.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExpenseCategory, ExpenseCategoryDTO>().ReverseMap();
        CreateMap<IncomeCategory, IncomeCategoryDTO>().ReverseMap();
        CreateMap<Expense, ExpenseDTO>().ReverseMap();
        CreateMap<Income, IncomeDTO>().ReverseMap();
    }
}
