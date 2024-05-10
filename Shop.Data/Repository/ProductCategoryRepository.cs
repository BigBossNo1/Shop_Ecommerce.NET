using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IProductCategoryRepository : IRepository<ProductCategorye>
    {
    }

    public class ProductCategoryRepository : Repository<ProductCategorye>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}