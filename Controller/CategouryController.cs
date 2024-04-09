using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokeymon_review_app.DTO;
using Pokeymon_review_app.Interfaces;
using Pokeymon_review_app.Models;

namespace Pokeymon_review_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategouryController : ControllerBase
    {
        private readonly ICategouryRepository _categouryRepository;
        private readonly IMapper _mapper;
        public CategouryController(ICategouryRepository categouryRepository, IMapper mapper)
        {
            _categouryRepository = categouryRepository;
            _mapper = mapper;
        }
        ////////////////Get all Categories////////////////////////
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {

            var Categories = _mapper.Map<List<CategouryDto>>(_categouryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(Categories);

        }
        [HttpGet("{CategouryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoury(int CategouryId)
        {
            if (!_categouryRepository.CategoryExists(CategouryId))
                return NotFound();
            var Categoury = _mapper.Map<CategouryDto>(_categouryRepository.GetCategory(CategouryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Categoury);

        }
        ////////////////Get Category by id////////////////////////
        [HttpGet("pokemon/{CategouryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategouryId(int CategouryId)
        {
            var pokemons = _mapper.Map<List<PokemonDTO>>
                (_categouryRepository.GetPokemonsByCatid(CategouryId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokemons);
        }
        ////////////////create new  Category////////////////////////
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategouryDto categouryCreate)
        {
            if (categouryCreate == null)
            {
                return BadRequest(ModelState);
            }
            var category = _categouryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categouryCreate.Name.TrimEnd())
                .FirstOrDefault();
            if (category != null)
            {
                ModelState.AddModelError("", "category already Exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categorymap = _mapper.Map<Category>(categouryCreate);
            if (!_categouryRepository.createCategory(categorymap))
            {
                ModelState.AddModelError("", "something went wrong While saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");

        }
        ////////////////Update Category////////////////////////
        [HttpPut("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategouryDto updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);
            if (categoryId != updatedCategory.Id)
                return BadRequest(ModelState);
            if (!_categouryRepository.CategoryExists(categoryId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var categorymap = _mapper.Map<Category>(updatedCategory);
            if (!_categouryRepository.UpdateCategory(categorymap))
            {
                ModelState.AddModelError("", "Something went Wrong Updating Csategory");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        ////////////////Delete Category////////////////////////
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categouryRepository.CategoryExists(categoryId))
                return NotFound();
            var categoryToDelete = _categouryRepository.GetCategory(categoryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_categouryRepository.DeleteCategory(categoryToDelete))
            {
                ModelState.AddModelError("", "something gets wrong While deleting");
            }
            return NoContent();


        }



    }
}
