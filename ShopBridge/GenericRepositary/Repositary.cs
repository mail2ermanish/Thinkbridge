using ShopBridge.IGenericRepositary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.GenericRepositary
{
    public class Repositary<T> : IGeneric<T> where T : class
    {

        private DbContext _context = null;
        public DbSet<T> table = null;

        public Repositary(DbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Additem(T obj)
        {
            table.Add(obj);
        }

        public void Deleteitem(T obj)
        {
            table.Remove(obj);
        }

        public async Task<IEnumerable<T>> Getallitems()
        {
            return await table.ToListAsync();
        }

        public void Updateitem(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}