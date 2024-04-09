namespace Pokeymon_review_app.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = new DateTime(1903, 1, 1);
    }
}
