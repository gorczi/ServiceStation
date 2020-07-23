using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Core.Shop;

namespace ServiceStation.Data.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }

        public Product Add(Product newProduct)
        {
            db.Add(newProduct);
            db.SaveChanges();
            return newProduct;
        }

        public Product Delete(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return product;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Update(Product updatedProduct)
        {
            var entity = db.Products.Attach(updatedProduct);
            entity.State = EntityState.Modified;
            db.SaveChanges();
            return updatedProduct;
        }
    }
}
