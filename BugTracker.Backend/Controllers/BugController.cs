using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]

public class BugController : ControllerBase
{
    private readonly IRepository<BugIssue> _repository;

    public BugController(IRepository<BugIssue> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<BugIssue>> GetAllBugs([FromQuery] int? skip, [FromQuery] int? limit)
    {
        return await _repository.GetAll(skip, limit);
    }

    // POST: create new bug
    [HttpPost]
    public async Task<IActionResult> CreateBug([FromBody] BugIssue bug)
    {
        BugIssue result =  await _repository.Create(bug);
        return CreatedAtAction("GetById", new {id = result.Id});
    }
    // PATCH: update bug
    [HttpPatch]
    public async Task<IActionResult> UpdateBug(BugIssue bug)
    {
        await _repository.Update(bug);
        return Ok();
    }


    // GET: get bug by id
    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetByGuid(Guid id)
    {
        BugIssue result = await _repository.GetByGuid(id);
        if(result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    // DELETE: delete bug by id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBugByGuid(Guid id)
    {
        await _repository.DeleteByGuid(id);
        return Ok();
    }
}

