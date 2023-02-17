using ElevenNote.Models.CategoryModels;

namespace ElevenNote.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CategoryCreate model);
        Task<List<CategoryListItem>> GetCategories();
    }
}