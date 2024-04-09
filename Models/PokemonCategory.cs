namespace Pokeymon_review_app.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon pokemon { get; set; }
        public Category Category { get; set; }
    }
}
