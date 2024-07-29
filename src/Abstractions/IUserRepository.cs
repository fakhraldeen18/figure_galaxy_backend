using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IUserRepository
{

    public IEnumerable<User> FindAll();
    public User? FindOne(Guid id);
    public User CreateOne(User NewUser);
    public User? DeleteOne(Guid id);
    public User UpdateOne(User UpdatedUser);

}
