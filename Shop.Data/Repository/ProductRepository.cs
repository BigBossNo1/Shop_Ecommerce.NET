using Shop.Data.Infastructure;
using Shop.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagID);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
        public IEnumerable<Product> GetListProductByTag(string tagID)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagID
                        select p;
            return query;
        }

    }
}