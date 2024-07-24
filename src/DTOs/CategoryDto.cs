namespace Anime_figures_backend.src.DTOs;
public class CategoryReadDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
}
public class CategoryCreateDto
{
    public string Type { get; set; }
}
public class CategoryUpdateDto
{
    public string Type { get; set; }
}