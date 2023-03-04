using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderService
{
    public class DbDaoOrder : IDaoOrder
    {
        private readonly ApplicationDbContext db;

        public DbDaoOrder(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Order> AddOrder(Order order)
        {
           await db.Orders.AddAsync(order);
            db.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            Order? order = await db.Orders.FirstOrDefaultAsync((order) => order.Id == id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                
            }
            return order !=null;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await db.Orders.ToListAsync();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
