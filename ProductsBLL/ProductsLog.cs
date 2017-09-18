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
        List<Product> LogProductbyId(int id);

    }
   public class ProductsLog: IProductsLog
        
    {
        public IEnumerable<Product> LogAllProducts()
        {
            var productRepository = new ProductRepository();
            var products = productRepository.GetAllProducts();
            return products;
        }

        public List<Product> LogProductbyId(int id)
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetProductbyId(id);
            return product;

        }



    }
}
