using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
    }

    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory)
                : base(dbFactory)
        {
        }
    }
}