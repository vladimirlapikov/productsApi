using ProductsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBLL
{
    public interface IProductCreateUpdate
    {
       void Create(Product p);
       void Update(int id,Product p);
       void Delete(int id);
    }

    public class ProductCreateUpdate : IProductCreateUpdate
    {
        public void Create(Product p)
        {
            var productRepository = new ProductRepository();
            productRepository.CreateProduct(p);
        }

        public void Update(int id, Product p)
        {
            var productRepository = new ProductRepository();
            productRepository.UpdateProduct(id , p);
        }

        public void Delete(int id)
        {
            var productRepository = new ProductRepository();
            productRepository.DeleteProduct(id);
        }
    }
}
