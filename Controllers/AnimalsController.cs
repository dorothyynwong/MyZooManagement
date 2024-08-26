using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;
using ZooManagement.Services;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalsRepo animals, IAnimalService animalService)
        {
            _animals = animals;
            _animalService = animalService;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetAnimalById(id);
            return new AnimalResponse(animal);
        }

        [HttpGet("")]
        public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            var animals = _animals.Search(searchRequest);
            var animalCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalCount);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var animal = _animals.Create(newAnimal);
            var animal = _animalService.Create(newAnimal);

            var url = Url.Action("GetById", new { id = animal.Id });
            var responseViewModel = new AnimalResponse(animal);
            return Created(url, responseViewModel);
        }
    }
}