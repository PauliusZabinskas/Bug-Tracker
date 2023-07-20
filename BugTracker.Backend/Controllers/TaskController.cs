using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly IRepository<TaskItem> _repository;
    private readonly IRepository<User> _userRepository;


    public TaskController(IRepository<TaskItem> repository, IRepository<User> userRepository)
    {
        _userRepository = userRepository;
        _repository = repository;
    }

    // GET: localhost:port/task/12
    [HttpGet("{id}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        TaskItem? result = await _repository.Get(id);
        // result is equal to null even with a valid id
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    // POST: localhost:port/task
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItem item, [FromQuery] Guid user)
    {
        
        item.CreatedBy = user;
        TaskItem result = await _repository.Create(item);

        // return CreatedAtAction("GetTaskById", new { id = result.Id });// result var must be present
        return Ok(result);
    }

    // PATCH: localhost:port/task
    [HttpPatch]
    public async Task<IActionResult> UpdateTask([FromBody] TaskItem item)
    {
        await _repository.Update(item);
        return Ok();
    }

    // DELETE: localhost:port/task/12
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskById(int id)
    {
        await _repository.Delete(id);
        return Ok();
    }

    // GET: localhost:port/task
    [HttpGet]
    public async Task<IActionResult> GetAllTasks([FromQuery] int? skip, [FromQuery] int? limit)
    {
        var result = await _repository.GetAll(skip, limit);
        return Ok(result);
    }

}