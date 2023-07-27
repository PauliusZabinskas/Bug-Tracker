using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]

public class BugController : ControllerBase
{
    private readonly IRepository<BugIssue> _repository;
    private readonly ICurrentUser _userService;

    public BugController(IRepository<BugIssue> repository, ICurrentUser userRepository)
    {
        _repository = repository;
        _userService = userRepository;

    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks([FromQuery] int? skip, [FromQuery] int? limit)
    {
        IEnumerable<BugIssue?> myTasks = await _repository.FindManyBy(x => x.CreatedBy == _userService.GetUser(), skip, limit);
        return Ok(myTasks);
    }

    // POST: create new bug
    [HttpPost]
    public async Task<IActionResult> CreateBug([FromBody] BugIssue bug)
    {
        int? currentUserId = _userService.GetUser();
        if (currentUserId != null)
        {
            BugIssue result =  await _repository.Create(bug);
            result.CreatedBy = currentUserId.Value;
            return CreatedAtAction("GetTaskById", new { result.Id }, result);
        }
        return BadRequest();
        
    }
    // PATCH: update bug
    [HttpPatch]
    public async Task<IActionResult> UpdateBug(BugIssue bug)
    {
        if(bug != null && bug.CreatedBy == _userService.GetUser())
        {
            await _repository.Update(bug);
            return Ok();

        }
        return Unauthorized(bug);
    }


    // GET: get bug by id
    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetByGuid(Guid id)
    {
        BugIssue result = await _repository.GetByGuid(id);
        if(result != null && result.CreatedBy == _userService.GetUser())
        {
            return Ok(result);
        } else if (result == null)
        {
            return NotFound();
        }
        return Unauthorized();
    }
    // DELETE: delete bug by id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBugByGuid(Guid id)
    {
        BugIssue result = await _repository.GetByGuid(id);
        if(result != null && result.CreatedBy == _userService.GetUser())
        {
            await _repository.DeleteByGuid(id);
            return Ok();

        } else if (result == null)
        {
            return NotFound();
        }
        return Unauthorized();
    }
}

