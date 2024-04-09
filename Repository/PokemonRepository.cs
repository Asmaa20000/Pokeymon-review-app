using Pokeymon_review_app.Data;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Repository
{
    public class PokemonRepository : IpokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.pokemons.OrderBy(p => p.Id).ToList();
        }
        public Pokemon GetPokemon(int id)
        {
            return _context.pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.pokemons.Where(p => p.Name == name).FirstOrDefault();
        }
        public decimal GetPokemonRating(int PokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == p.Id);
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public bool PokemonExists(int PokeId)
        {
            return _context.pokemons.Any(p => p.Id == PokeId);
        }

        /// ///////////////////not working//////////
        public bool createPokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId)
                .FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == ownerId)
               .FirstOrDefault();
            var pockemonOwner = new PokeymonOwner()
            {
                owner = pokemonOwnerEntity,
                pokemon = pokemon,
            };
            _context.Add(pockemonOwner);
            var pockemonCategory = new PokemonCategory()
            {
                Category = category,
                pokemon = pokemon,
            };
            _context.Add(pockemonCategory);
            _context.Add(pokemon);
            return save();
            //if (pokemonOwnerEntity != null) { }
        }
        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return save();
        }
        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return save();
        }
        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
