namespace Anime_figures_backend.src.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; } // Foreign Key
    public Guid OrderId { get; set; } // Foreign Key
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}