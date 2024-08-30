using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;
using ZooManagement.Services;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooKeeperController : ControllerBase
    {
        private readonly ILogger<ZooKeeperController> _logger;
        private readonly IZooKeepersRepo _zooKeepers;
        private readonly IAnimalService _animalService;
        
        public ZooKeeperController(ILogger<ZooKeeperController> logger, IZooKeepersRepo zooKeepers, IAnimalService animalService)
        {
            _logger = logger;
            _zooKeepers= zooKeepers;
            _animalService = animalService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ZooKeeperResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<ZooKeeperResponse> GetById([FromRoute] int id)
        {
            try
            {
                var zooKeeper = _zooKeepers.GetZooKeeperById(id);
                return new ZooKeeperResponse(zooKeeper);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Business logic error: {Message}", ex.Message);
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Business logic error.", Details = ex.Message });
            }

        }

        // [HttpPost("create")]
        // [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ZooKeeperResponse))]
        // [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        // public IActionResult Create([FromBody] CreateZooKeeperRequest newZooKeeper)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     try
        //     {
        //         var zooKeeper = _zooKeepers.Create(newZooKeeper);
        //         var url = Url.Action("GetById", new { id = zooKeeper.Id });
        //         var responseViewModel = new ZooKeeperResponse(zooKeeper);
        //         return Created(url, responseViewModel);
        //     }
        //     catch(InvalidOperationException ex)
        //     {
        //         _logger.LogWarning(ex, "Business logic error: {Message}", ex.Message);
        //         return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Business logic error.", Details = ex.Message });
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Unexpected error occurred.");
        //         return StatusCode(500, new ErrorResponse { StatusCode = 500, Message = "An unexpected error occurred.", Details = ex.Message });
        //     }
        // }
    }
}