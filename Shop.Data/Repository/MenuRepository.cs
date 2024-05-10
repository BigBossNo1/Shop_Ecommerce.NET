using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IMenuRepository : IRepository<Menu>
    {
    }

    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}