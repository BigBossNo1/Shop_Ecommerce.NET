using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}