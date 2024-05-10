using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : Repository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}