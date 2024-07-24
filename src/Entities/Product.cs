namespace Anime_figures_backend.src.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; } // Foreign Key
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Inventory> Inventories { get; set; } // Navigation Inventory
}
