namespace Pokeymon_review_app.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = new DateTime(1903, 1, 1);
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokeymonOwner> Pokeymonowners { get; set; }
        public ICollection<PokemonCategory> Pokeymoncategories { get; set; }
    }
}
