using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    //[Authorize]
    //["Authorization" : Basic{"kplacido0"}:{"kplacido0"}]
    // [BasicAuthentication( username,password )]
    [Route("/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        // [Authorize] commented by Dorothy
        // [HttpGet("")]
        // public ActionResult<UserListResponse> Search([FromQuery] UserSearchRequest searchRequest)
        // {
        //     var users = _users.Search(searchRequest);
        //     var userCount = _users.Count(searchRequest);
        //     return UserListResponse.Create(searchRequest, users, userCount);
        // }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetAnimalById(id);
            return new AnimalResponse(animal);
        }

        // [HttpGet("{speciesid}")]
        [HttpGet("")]
        public ActionResult<AnimalListResponse> GetBySpeciesId([FromQuery] AnimalSearchRequest searchRequest)
        {
            // var animal = _animals.GetAnimalBySpeciesID(id);
            // return new AnimalResponse(animal);
            var animals = _animals.Search(searchRequest);
            var animalCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalCount);
        }


        //[Authorize]
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = _animals.Create(newAnimal);

            var url = Url.Action("GetById", new { id = animal.Id });
            var responseViewModel = new AnimalResponse(animal);
            return Created(url, responseViewModel);
        }

        // [Authorize]
        // [HttpPatch("{id}/update")]
        // public ActionResult<UserResponse> Update([FromRoute] int id, [FromBody] UpdateUserRequest update)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var user = _users.Update(id, update);
        //     return new UserResponse(user);
        // }

        // [Authorize]
        // [HttpDelete("{id}")]
        // public IActionResult Delete([FromRoute] int id)
        // {
        //     _users.Delete(id);
        //     return Ok();
        // }
    }
}