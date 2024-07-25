using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;
public interface IImageRepository
{

    public IEnumerable<Image> FindAll();
    public Image? FindOne(Guid id);
    public Image CreateOne(Image NewImage);
    public Image? DeleteOne(Guid id);
    public Image UpdateOne(Image UpdateImage);

}
