namespace Anime_figures_backend.src.DTOs;

public class InventoryReadDto
{

    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
    public int Price { get; set; }
}
public class InventoryCreateDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
    public int Price { get; set; }
}
public class InventoryUpdateDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
    public int Price { get; set; }
}
