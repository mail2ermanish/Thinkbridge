using ShopBridge.GenericRepositary;
using ShopBridge.IProduct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopBridge.Models;

namespace ShopBridge.ProductRepo
{
    public class Productrepo : Repositary<Product>, IProductdetail
    {
        private DbContext _context = null;
        public Productrepo(DbContext context) : base(context)
        {
            _context = context;
        }


    }
}