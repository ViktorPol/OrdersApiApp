using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
