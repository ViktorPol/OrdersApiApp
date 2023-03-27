using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDaoOrderProduct
    {
        private readonly ApplicationDbContext db;

        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<OrderProduct> AddOrderProduct(OrderProduct orderproduct)
        {
            await db.OrderProducts.AddAsync(orderproduct);
            db.SaveChangesAsync();
            return orderproduct;
        }

        public async Task<bool> DeleteOrderProduct(int id)
        {
            OrderProduct? orderproduct = await db.OrderProducts.FirstOrDefaultAsync((orderproduct) => orderproduct.Id == id);
            if (orderproduct != null)
            {
                db.OrderProducts.Remove(orderproduct);
                db.SaveChanges();

            }
            return orderproduct != null;
        }

        public async Task<List<OrderProduct>> GetAllOrderProducts()
        {
            return await db.OrderProducts.ToListAsync();
        }

        public Task<OrderProduct> GetOrderProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderProduct> UpdateOrderProduct(OrderProduct orderproduct)
        {
            db.OrderProducts.Update(orderproduct);
            await db.SaveChangesAsync();
            return orderproduct;
        }
    }
}
