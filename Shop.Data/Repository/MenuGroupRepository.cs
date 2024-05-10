using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IMenuGroupRepository : IRepository<MenuGroup>
    {
    }

    public class MenuGroupRepository : Repository<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}