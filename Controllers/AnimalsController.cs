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
        private readonly ILogger<AnimalController> _logger;
        private readonly IAnimalsRepo _animals;
        private readonly IAnimalService _animalService;
        

        public AnimalController(ILogger<AnimalController> logger, IAnimalsRepo animals, IAnimalService animalService)
        {
            _logger = logger;
            _animals = animals;
            _animalService = animalService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimalResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            try
            {
                var animal = _animalService.GetAnimalById(id);
                return new AnimalResponse(animal);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Business logic error: {Message}", ex.Message);
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Business logic error.", Details = ex.Message });
            }

        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimalListResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<AnimalDetailsListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            try
            {
                var animals = _animalService.Search(searchRequest);
                var animalCount = _animalService.Count(searchRequest);
                return AnimalDetailsListResponse.Create(searchRequest, animals, animalCount);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Business logic error: {Message}", ex.Message);
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Business logic error.", Details = ex.Message });
            }

        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AnimalResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var animal = _animalService.Create(newAnimal);
                var url = Url.Action("GetById", new { id = animal.Id });
                var responseViewModel = new AnimalResponse(animal);
                return Created(url, responseViewModel);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Business logic error: {Message}", ex.Message);
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Business logic error.", Details = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred.");
                return StatusCode(500, new ErrorResponse { StatusCode = 500, Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }
    }
}