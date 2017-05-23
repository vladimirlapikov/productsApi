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
        public ProductsController() { }

        public ProductsController(IProductsCalculator productsCalculator, IProductsLog productsLog)
        {
            _productsCalculator = productsCalculator;
            _productsLog = productsLog;
        }

        public int GetProductsCount()
        {
            return _productsCalculator.CountAllProducts();
        }

        [Route("details")]
        public List<Product> GetAllProductsLog()
        {
            
            return _productsLog.LogAllProducts().ToList();

        }

        public List<Product> GetProductbyId(int id)
        {
            int _id = id;
            return _productsLog.LogProductbyId(_id).ToList();

        }

    }
}
