using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.IGenericRepositary
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> Getallitems();
        void Additem(T obj);
        void Updateitem(T obj);
        void Deleteitem(T obj);


    }
}