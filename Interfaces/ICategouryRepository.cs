using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Interfaces
{
    public interface ICategouryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonsByCatid(int CategoryId);
        bool CategoryExists(int CategoryId);
        bool createCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool save();


    }
}
