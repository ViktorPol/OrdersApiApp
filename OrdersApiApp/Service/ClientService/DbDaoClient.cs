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

        public Task<bool> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
