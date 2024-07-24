namespace Anime_figures_backend.src.Entities;

public class Inventory
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; } // Foreign Key
    public int Quantity { get; set; }
    public string Size { get; set; }
    public int Price { get; set; }
    public List<OrderItem> OrderItems { get; set; } // Navication Order Item
    public List<Image> Images { get; set; } // Navication Images
}
