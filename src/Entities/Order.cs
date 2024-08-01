namespace Anime_figures_backend.src.Entities;
public class Order
{

    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Foreign Key
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Status { get; set; }
    public List<OrderItem> OrderItems { get; set; } // Navigation Order Items
}
