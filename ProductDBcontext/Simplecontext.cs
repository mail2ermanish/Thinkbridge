using System;
using System.Data.Entity;
using Modelclass;

namespace ProductDBcontext
{
    public class Simplecontext:DbContext
    {
        public Simplecontext():base("name=Studentconnectionstring")
        {
            
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
