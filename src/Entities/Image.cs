namespace Anime_figures_backend.src.Entities;

public class Image
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; } // Foreign Key
    public string Url { get; set; }
    public bool IsPrimary { get; set; }

}
