namespace Anime_figures_backend.src.DTOs;

public class ProductReadDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class ProductCreateDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class ProductUpdateDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
