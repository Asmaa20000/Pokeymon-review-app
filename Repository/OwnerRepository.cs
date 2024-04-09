using Pokeymon_review_app.Data;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return save();

        }


        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOFAPokemon(int PokeId)
        {
            return _context.pokemonowners.Where(p => p.PokemonId == PokeId)
                 .Select(o => o.owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int OwnerId)
        {
            return _context.pokemonowners.Where(o => o.OwnerId == OwnerId)
                .Select(p => p.pokemon)
                .ToList();
        }

        public bool OwnerExists(int OwnerId)
        {
            return _context.Owners.Any(o => o.Id == OwnerId);
        }
        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return save();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return save();
        }
    }
}
