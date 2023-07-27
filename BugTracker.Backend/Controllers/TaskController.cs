using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly IRepository<TaskItem> _repository;
    private readonly ICurrentUser _userService;

    public TaskController(IRepository<TaskItem> repository, ICurrentUser userService)
    {
        _userService = userService;
        _repository = repository;
    }

    // GET: localhost:port/task/12
    [HttpGet("{id}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        TaskItem? result = await _repository.Get(id);
        // result is equal to null even with a valid id
        if(result != null && result.CreatedBy == _userService.GetUser()) {
            return Ok(result);
        } else if(result == null) {
            return NotFound();
        }

        return Unauthorized();
    }

    // POST: localhost:port/task
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItem item )
    {
        int? currentUserId = _userService.GetUser();

        if(currentUserId != null)
        {
            item.CreatedBy = currentUserId.Value;
        // User user = await _userRepository.GetUser(id);
            TaskItem result = await _repository.Create(item);

            return CreatedAtAction("GetTaskById", new { result.Id }, result);
        }

        return BadRequest();
    }

    // PATCH: localhost:port/task
    [HttpPatch]
    public async Task<IActionResult> UpdateTask([FromBody] TaskItem item)
    {
        if(item != null && item.CreatedBy == _userService.GetUser())
        {
            await _repository.Update(item);
            return Ok();

        } else if(item == null)
        {
            return NotFound();
        }

        return Unauthorized();
    }

    // DELETE: localhost:port/task/12
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskById(int id)
    {
        TaskItem? result = await _repository.Get(id);
        if(result != null && result.CreatedBy == _userService.GetUser())
        {
            await _repository.Delete(id);
            return Ok();
        } else if(result == null)
        {
            return NotFound();
        }
        return Unauthorized();
    }

    // GET: localhost:port/task
    [HttpGet]
    public async Task<IActionResult> GetAllTasks([FromQuery] int? skip, [FromQuery] int? limit)
    {
        IEnumerable<TaskItem?> myTasks = await _repository.FindManyBy(x => x.CreatedBy == _userService.GetUser(), skip, limit);
        return Ok(myTasks);
    }

}