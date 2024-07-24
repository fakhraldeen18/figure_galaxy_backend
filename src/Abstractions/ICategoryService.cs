using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryReadDto> FindAll();
        public CategoryReadDto? FindOne(Guid Id);
        public CategoryReadDto CreateOne(CategoryCreateDto NewCategory);
        public bool DeleteOne(Guid id);
        public CategoryReadDto? UpdateOne(Guid id,CategoryUpdateDto UpdatedCategory);

    }
}