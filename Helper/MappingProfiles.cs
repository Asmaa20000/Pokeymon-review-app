using AutoMapper;
using Pokeymon_review_app.DTO;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<PokemonDTO, Pokemon>();
            CreateMap<Category, CategouryDto>();
            CreateMap<CategouryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Reviewer, ReviewrDto>();
            CreateMap<ReviewrDto, Reviewer>();

        }
    }
}
