using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MoneyApp.Server.Data
{
    public class DataIdentityContext : IdentityDbContext
    {
        public DataIdentityContext(DbContextOptions<DataIdentityContext> options) : base(options)
        {

        }
    }
}
