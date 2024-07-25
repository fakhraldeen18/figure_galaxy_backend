using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly DbSet<Image> _images;
    private readonly DatabaseContext _databaseContext;

    public ImageRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _images = databaseContext.Images;
    }

    public Image CreateOne(Image NewImage)
    {
        _images.Add(NewImage);
        _databaseContext.SaveChanges();
        return NewImage;
    }

    public Image? DeleteOne(Guid id)
    {
        Image? FindImage = FindOne(id);
        _images.Remove(FindImage!);
        _databaseContext.SaveChanges();
        return FindImage;
    }

    public IEnumerable<Image> FindAll()
    {
        IEnumerable<Image> Images = _images;
        return Images;
    }

    public Image? FindOne(Guid id)
    {
        Image? FindImage = _images.FirstOrDefault(i => i.Id == id);
        return FindImage;
    }

    public Image UpdateOne(Image UpdateImage)
    {
        _images.Update(UpdateImage);
        _databaseContext.SaveChanges();
        return UpdateImage;
    }
}
