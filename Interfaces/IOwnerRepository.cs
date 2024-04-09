using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOFAPokemon(int PokeId);
        ICollection<Pokemon> GetPokemonByOwner(int OwnerId);
        bool OwnerExists(int OwnerId);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool save();
    }
}
