using Anime_figures_backend.src.Entities;
using Anime_figures_backend.src.Enums;
using Microsoft.EntityFrameworkCore;
namespace Anime_figures_backend.src.Databases;
public class DatabaseContext : DbContext // DbContext is built in class to give me access to database (gateway to database)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Product> Products { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>(); // add the type Role
    }
}







