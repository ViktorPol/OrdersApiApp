using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ClientService
{
    public class DbDaoClient: IDaoClient
    {
        private readonly ApplicationDbContext db;

        public DbDaoClient(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Client> AddClient(Client client)
        {
            await db.Clients.AddAsync(client);
            db.SaveChanges();
            return client;
        }

        public async Task<bool> DeleteClient(int id)
        {
            Client? client = await db.Clients.FirstOrDefaultAsync((client) => client.Id == id);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return true;
            }
            return true;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
            return client;
        }
    }
}
