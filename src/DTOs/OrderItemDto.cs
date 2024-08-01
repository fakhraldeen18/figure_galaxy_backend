namespace Anime_figures_backend.src.DTOs;

public class OrderItemReadDto
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; } // Foreign Key
    public Guid OrderId { get; set; } // Foreign Key
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
public class OrderItemCreateDto
{
    public Guid InventoryId { get; set; } // Foreign Key
    public Guid OrderId { get; set; } // Foreign Key
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
