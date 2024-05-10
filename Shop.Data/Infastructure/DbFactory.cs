namespace Shop.Data.Infastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopDbContext _DbContex;

        public ShopDbContext Init()
        {
            return _DbContex ?? (_DbContex = new ShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (_DbContex != null)
            {
                _DbContex.Dispose();
            }
        }
    }
}