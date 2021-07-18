using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace ShopBridge.Persistence
{

    public class UnitofWork : IUnitofWork
    {
        private DbContext _context = null;
        public UnitofWork()
        {
            _context = new Simplecontext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DbContext GetDBContectinstance()
        {
            return _context;
        }

        public async Task saveasync()
        {
            await _context.SaveChangesAsync();
        }
    }
}