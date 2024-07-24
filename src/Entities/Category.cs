using System.ComponentModel.DataAnnotations;

namespace Anime_figures_backend.src.Entities;

public class Category
{

    public Guid Id { get; set; }
    [Required]
    public string Type { get; set; }
    public List<Product> Products { get; set; } // Navigation Product

}
