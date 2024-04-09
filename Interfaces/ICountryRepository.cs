using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int OwnerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        bool countryExists(int countryId);
        bool createCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool save();
    }
}
