using ProductsBLL;
using ProductsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductsCalculator _productsCalculator;
        private readonly IProductsLog _productsLog;
        private readonly IProductCreateUpdate _productCreateUpdate;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductsController() { }

        public ProductsController(IProductsCalculator productsCalculator, IProductsLog productsLog , IProductCreateUpdate productCreateUpdate)
        {
            _productsCalculator = productsCalculator;
            _productsLog = productsLog;
            _productCreateUpdate = productCreateUpdate;
        }

        public int GetProductsCount()
        {
            log.Info("Counting Objects");
            return _productsCalculator.CountAllProducts();
        }

        [Route("details")]
        public List<Product> GetAllProductsLog()
        {
            
            return _productsLog.LogAllProducts().ToList();

        }

        public List<Product> GetProductbyId(int id)
        {
            
            return _productsLog.LogProductbyId(id);

        }

        public HttpResponseMessage Post([FromBody]Product p)
        {
            _productCreateUpdate.Create(p);
            var message = Request.CreateResponse(HttpStatusCode.Created , p );
            message.Headers.Location = new Uri(Request.RequestUri + p.Id.ToString());
            return message;                     
        }

        public HttpResponseMessage Put(int id,[FromBody]Product p)
        {
            
            try
            {
                _productCreateUpdate.Update(id, p);
                if (p == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product Not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Product Updated Successfully");
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                _productCreateUpdate.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Product Deleted Successfully");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
                
            

        }

    }
}
