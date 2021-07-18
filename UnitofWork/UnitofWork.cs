using System;
using System.Data.Entity;
using System.Threading.Tasks;
using InterfaceUnitofWork;
using ProductDBcontext;


namespace UnitofWork
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

        public  DbContext GetDBContectinstance()
        {
            return  _context;
        }

        public  void save()
        {
            _context.SaveChanges();
        }
    }
}
