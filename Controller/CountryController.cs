using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokeymon_review_app.DTO;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {

            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(countries);

        }
        [HttpGet("{CountryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int CountryId)
        {
            if (!_countryRepository.countryExists(CountryId))
                return NotFound();

            var Country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(CountryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Country);

        }
        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(country);

        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto CountryCreate)
        {
            if (CountryCreate == null)
                return BadRequest(ModelState);
            var country = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == CountryCreate.Name.TrimEnd())
                .FirstOrDefault();
            if (country != null)
            {
                ModelState.AddModelError("", "category already Exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var countrymap = _mapper.Map<Country>(CountryCreate);
            if (!_countryRepository.createCountry(countrymap))
            {
                ModelState.AddModelError("", "something went wrong While saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }
        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updatedCountry)
        {
            if (updatedCountry == null)
                return BadRequest(ModelState);
            if (countryId != updatedCountry.Id)
                return BadRequest(ModelState);
            if (!_countryRepository.countryExists(countryId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var countrymap = _mapper.Map<Country>(updatedCountry);
            if (!_countryRepository.UpdateCountry(countrymap))
            {
                ModelState.AddModelError("", "Something went Wrong Updating Csategory");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        ////////////////Delete Country////////////////////////
        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.countryExists(countryId))
                return NotFound();
            var countryToDelete = _countryRepository.GetCountry(countryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_countryRepository.DeleteCountry(countryToDelete))
            {
                ModelState.AddModelError("", "something gets wrong While deleting");
            }
            return NoContent();


        }


    }
}
