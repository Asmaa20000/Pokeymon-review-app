using Pokeymon_review_app.Data;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Repository
{
    public class CategoryRepository : ICategouryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public Category GetCategory(int id)
        {
            return _context.Categories
                .Where(c => c.Id == id).FirstOrDefault();
        }
        public bool CategoryExists(int CategoryId)
        {
            return _context.Categories.Any(c => c.Id == CategoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public ICollection<Pokemon> GetPokemonsByCatid(int CategoryId)
        {
            return _context.pokemoncategories.Where(e => e.CategoryId == CategoryId)
                  .Select(p => p.pokemon).ToList();
        }

        public bool createCategory(Category category)
        {
            _context.Add(category);
            return save();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return save();
        }
    }
}
