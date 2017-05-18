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
    public class ProductsController : ApiController
    {
        private readonly IProductsCalculator _productsCalculator;
        private readonly IProductsLog _productsLog;

        public ProductsController(IProductsCalculator productsCalculator)
        {
            _productsCalculator = productsCalculator;
        }

        public int GetProductsCount()
        {
            //var calc = new ProductsCalculator(new ProductRepository());
            return _productsCalculator.CountAllProducts();
        }
       

        public List<Product> GetAllProductsLog(int id)
        {
            int _id = id;
            var list = new ProductsLog();
            return list.LogAllProducts().ToList();

        }
    }
}
