using System;
using System.Data.Entity;

namespace InterfaceUnitofWork
{
    public interface IUnitofWork:IDisposable
    {
        DbContext GetDBContectinstance();
        void save();
    }
}
