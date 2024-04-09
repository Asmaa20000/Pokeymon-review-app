using Microsoft.EntityFrameworkCore;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<PokemonCategory> pokemoncategories { get; set; }
        public DbSet<PokeymonOwner> pokemonowners { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                  .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            //بقوله عايزه اربط   ids2
            modelBuilder.Entity<PokemonCategory>()
                  .HasOne(p => p.pokemon)
                  .WithMany(pc => pc.Pokeymoncategories)
                  .HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<PokemonCategory>()
                 .HasOne(p => p.Category)
                 .WithMany(pc => pc.PokemonCategories)
                 .HasForeignKey(c => c.PokemonId);
            /////////////////////////////
            ///
            modelBuilder.Entity<PokeymonOwner>()
                  .HasKey(pc => new { pc.PokemonId, pc.OwnerId });
            //بقوله عايزه اربط   ids2
            modelBuilder.Entity<PokeymonOwner>()
                  .HasOne(p => p.pokemon)
                  .WithMany(po => po.Pokeymonowners)
                  .HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokeymonOwner>()
                 .HasOne(p => p.owner)
                 .WithMany(po => po.Pokymonowners)
                 .HasForeignKey(c => c.OwnerId);
        }

    }
}
