using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
        public MySqlContext() { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "Name", Price = 69.9M, Description = "Alguma descrição", CategoryName = "Teste", ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true" },
                new Product { Id = 10 , Name = "Marina",Description = "Nova descrição",Price = 1599.99M, CategoryName = "Teste",ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true" },
                new Product { Id = 11, Name = "Marina", Description = "Nova descrição", Price = 1599.99M, CategoryName = "Teste", ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true" },
                new Product { Id = 12, Name = "Marina", Description = "Nova descrição", Price = 1599.99M, CategoryName = "Teste", ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
