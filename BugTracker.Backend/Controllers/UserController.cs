
using BugTracker.Backend.Data;
using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;

// API controller attribute tells the compiler on start up
// to map all the endpoints of this controller
[ApiController]
// The route attribute tells the compiler at run time
// that the mapping it should make of the endpoints in this
// controller, should be on the route "[controller]"
// [controller] is relaced on runtime to the name of the class
// minus the suffix "Controller"
[Route("[controller]")]
// While the [ApiController] attribute tells the compiler
// on startup that this is a controller, by inheriting from
// ControllerBase, get get out of the box functionality
// required by controllers.
public class UserController : ControllerBase
{
    // readonly specifies that this field should be immutable.
    // If this field could change, whats the point of dependency injection?
    private readonly IRepository<User> _repository;

    // Registered IRepository as a service that will be
    // resolved to EfCoreRepository (see Program.cs)
    public UserController(IRepository<User> repository)
    {
        // readonly fields can only be initialised
        // inline, or in a constructor.
        _repository = repository;
    }

    // localhost:port/auth?skip=10
    // localhost:port/auth?take=10
    // localhost:port/auth?skip=10&take=20
    // localhost:port/auth

    // Final goal:
    // localhost:port/auth?skip=10&take=20&filter=Mich&sort=newest
    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] int? skip, [FromQuery] int? take)
    {
        IEnumerable<User> users = await _repository.GetAll(take, skip);
        return Ok(users);
    }

    [HttpGet("{id}", Name = "GetByGuid")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        User result = await _repository.GetByGuid(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        User result = await _repository.Create(user);
        // result.Id = new Guid();
        return CreatedAtAction("GetByGuid", new { id = result.Id });
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        await _repository.Update(user);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _repository.DeleteByGuid(id);
        return Ok();

    }
}