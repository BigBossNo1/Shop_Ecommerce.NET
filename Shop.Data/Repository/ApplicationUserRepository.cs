using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }

    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory)
        : base(dbFactory)
        {
        }
    }
}