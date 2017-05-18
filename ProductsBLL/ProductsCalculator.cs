using ProductsDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsBLL
{
    public interface IProductsCalculator
    {
       int CountAllProducts(); 
        
    }

    public class ProductsCalculator : IProductsCalculator
    { 


        public int CountAllProducts()
        {
            var productRepository = new ProductRepository();
            var products = productRepository.GetAllProductsCount();
            return products.Count();
            
        }
    }
}
