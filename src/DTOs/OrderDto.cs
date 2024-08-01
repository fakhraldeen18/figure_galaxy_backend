using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.DTOs;

public class OrderReadDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Foreign key
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Status { get; set; }
    public List<OrderItem>? OrderItem { get; set; } // Navigation Property
}

public class CheckoutDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
}
