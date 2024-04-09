namespace Pokeymon_review_app.Models
{
    public class PokeymonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon pokemon { get; set; }
        public Owner owner { get; set; }
    }
}
