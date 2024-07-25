namespace Anime_figures_backend.src.DTOs;
public class ImageReadDto
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; }
    public string Url { get; set; }
    public bool IsPrimary { get; set; }

}
public class ImageCreateDto
{
    public Guid InventoryId { get; set; }
    public string Url { get; set; }
    public bool IsPrimary { get; set; }

}
public class ImageUpdateDto
{
    public Guid InventoryId { get; set; }
    public string Url { get; set; }
    public bool IsPrimary { get; set; }

}
