using System;

namespace Shop.Data.Infastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopDbContext Init();
    }
}