namespace Shop.Data.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        // Partern lưu lại SavaChange()
        private readonly IDbFactory dbFactory;

        private ShopDbContext _DbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public ShopDbContext DbContext
        {
            get { return _DbContext ?? (_DbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}