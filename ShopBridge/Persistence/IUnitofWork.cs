using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ShopBridge.Persistence
{
    public interface IUnitofWork : IDisposable
    {
        DbContext GetDBContectinstance();
        Task saveasync();
    }
}