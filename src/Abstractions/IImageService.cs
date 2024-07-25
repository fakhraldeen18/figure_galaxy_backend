using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions;
public interface IImageService
{
    public IEnumerable<ImageReadDto> FindAll();
    public ImageReadDto? FindOne(Guid id);
    public ImageReadDto? CreateOne(ImageCreateDto NewImage);
    public bool DeleteOne(Guid id);
    public ImageReadDto? UpdateOne(Guid id,ImageUpdateDto UpdateImage);

}
