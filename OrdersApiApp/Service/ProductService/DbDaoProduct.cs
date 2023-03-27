using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ProductService
{
    public class DbDaoProduct : IDaoProduct
    {
        private readonly ApplicationDbContext db;

        public DbDaoProduct(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await db.Products.AddAsync(product);
            db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product? product = await db.Products.FirstOrDefaultAsync((product) => product.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();

            }
            return product != null;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
