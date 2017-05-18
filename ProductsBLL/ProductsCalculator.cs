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

        private readonly IProductRepository _productRepository;
        public ProductsCalculator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int CountAllProducts()
        {
            var products = _productRepository.GetAllProductsCount();
            return products.Count();
            
        }
    }
}
