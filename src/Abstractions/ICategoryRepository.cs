using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface ICategoryRepository
{
    public IEnumerable<Category> FindAll();
    public Category? FindOne(Guid Id);
    public Category CreateOne(Category NewCategory);
    public Category? DeleteOne(Guid id);
    public Category UpdateOne(Category UpdatedCategory);

}
