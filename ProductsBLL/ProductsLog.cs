using ProductsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBLL
{
    public interface IProductsLog
    {
        IEnumerable<Product> LogAllProducts();

    }
   public class ProductsLog: IProductsLog
        
    {
        public IEnumerable<Product> LogAllProducts()
        {
            var productRepository = new ProductRepository();
            var products = productRepository.GetAllProducts();
            return products;

        }
    }
}
