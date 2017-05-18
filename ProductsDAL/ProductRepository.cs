using System.Collections.Generic;
using System.Linq;

namespace ProductsDAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProductsCount();
        IEnumerable<Product> GetAllProducts();
    }

    public class ProductRepository : IProductRepository
    {
        //ProductsDBEntities db = new ProductsDBEntities();

        public IEnumerable<Product> GetAllProductsCount()
        {
            using (var db = new ProductsDBEntities())
            {
                return db.Products.ToList();
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var db = new ProductsDBEntities())
            {

                return db.Products.ToList();
            }
        }
    }
}

