using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ShopBridge.GenericRepositary;
using ShopBridge.IGenericRepositary;
using ShopBridge.IProduct;
using ShopBridge.Models;
using ShopBridge.Persistence;
using ShopBridge.ProductRepo;

namespace ShopBridge.Controllers
{
    public class ProductController : ApiController
    {
        private IUnitofWork _unitofwork=null;
        private DbContext _context=null;
        private IProductdetail _product = null;
        private IGeneric<Product> _generic = null;

        public ProductController()
        {
            _unitofwork = new UnitofWork();
            _context = _unitofwork.GetDBContectinstance();
            _product = new Productrepo(_context);
            _generic = new Repositary<Product>(_context);

        }

        // GET api/values

        
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var list = await _generic.Getallitems();
                var message= Request.CreateResponse(HttpStatusCode.OK,list);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET api/values/5
   

        // POST api/values
        public async Task<HttpResponseMessage> Post([FromBody] Product prod)
        {
            try
            {
             
                if (ModelState.IsValid)
                {
                    _generic.Additem(prod);
                  await  _unitofwork.saveasync();
                   var  message = Request.CreateResponse(HttpStatusCode.Created, prod);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        prod.ID.ToString());
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }
               
            }
            catch (Exception ex)
            {
               
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT api/values/5/
        public async  Task<HttpResponseMessage> Put(int id, [FromBody] Product prod)
        {
            try
            {
                var products = await _generic.Getallitems();
                Product p = products.FirstOrDefault(x => x.ID == id);
                if (p != null)
                {
                    p.Name = prod.Name;
                    p.Description = prod.Description;
                    p.Price = prod.Price;
                    _generic.Updateitem(p);
                   await _unitofwork.saveasync();
                    return Request.CreateResponse(HttpStatusCode.OK, "Product with ID " + id + " is updated successfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product with ID " + id + " does not exist");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var p =await _generic.Getallitems();
                Product prod = p.FirstOrDefault(x => x.ID == id);
                if (prod!=null)
                {
                    _generic.Deleteitem(prod);
                   await _unitofwork.saveasync();

                    return Request.CreateResponse(HttpStatusCode.OK, "Product with ID "+ id +" is deleted successfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product with ID "+id+" does not exist");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
