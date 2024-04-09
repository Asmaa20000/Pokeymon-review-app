using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Interfaces
{
    public interface IpokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int PokeId);
        bool PokemonExists(int PokeId);
        bool createPokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        bool DeletePokemon(Pokemon pokemon);
        bool save();

    }
}
