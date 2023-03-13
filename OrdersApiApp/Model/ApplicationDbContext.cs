using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        // конфигурация контекста

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Client)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("UseConnectionString"));
        }
    }
}
