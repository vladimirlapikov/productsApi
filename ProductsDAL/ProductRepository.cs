using System.Collections.Generic;
using System.Linq;

namespace ProductsDAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProductsCount();
        IEnumerable<Product> GetAllProducts();
        List<Product> GetProductbyId(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }

    public class ProductRepository : IProductRepository
    {
       

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

        public List<Product> GetProductbyId(int id)
        {
            using (var db = new ProductsDBEntities())
            {
                // thats way using sp !!!
                //var byCat = db.GetProductaByCategory("gghghg");
                return db.Products.Where(p => p.Id == id).ToList();

            }
        }

        public void CreateProduct(Product product)
        {
            using (var db = new ProductsDBEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void UpdateProduct(int id,Product product)
        {
            using (var db = new ProductsDBEntities())
            {
                var entity = db.Products.SingleOrDefault(p => p.Id == id);
                entity.Name = product.Name;
                entity.Price = product.Price;
                entity.Category = product.Category;
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var db = new ProductsDBEntities())
            {
                var entity = db.Products.SingleOrDefault(p => p.Id == id);
                db.Products.Remove(entity);
                db.SaveChanges();
            }
        }


    }
}

