using Pokeymon_review_app.Data;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool countryExists(int countryId)
        {
            return _context.countries.Any(c => c.Id == countryId);
        }

        public bool createCountry(Country country)
        {
            _context.Add(country);
            return save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.countries.Where(e => e.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int OwnerId)
        {
            return _context.Owners.Where(o => o.Id == OwnerId)
                .Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return save();
        }
        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
