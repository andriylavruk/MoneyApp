using MoneyApp.Shared.DTO;

namespace MoneyApp.Server.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExpenseCategory, ExpenseCategoryDTO>().ReverseMap();
        CreateMap<Expense, ExpenseDTO>().ReverseMap();
    }

}
