using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace ShopBridge.Persistence
{
    public class Simplecontext : DbContext
    {
        public Simplecontext() : base("name=Studentconnectionstring")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Simplecontext, ShopBridge.Migrations.Configuration>());
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}