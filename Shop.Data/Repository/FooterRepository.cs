using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IFooterRepository : IRepository<Footer>
    {
    }

    public class FooterRepository : Repository<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}