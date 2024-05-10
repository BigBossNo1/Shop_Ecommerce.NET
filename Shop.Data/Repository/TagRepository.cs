using Shop.Data.Infastructure;
using Shop.Models.Models;

namespace Shop.Data.Repository
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}