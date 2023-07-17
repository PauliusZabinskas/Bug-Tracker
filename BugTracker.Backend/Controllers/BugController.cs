using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[contoller]")]

public class BugController : ControllerBase
{
    private readonly IRepository<Bug> _repository;

    public BugController(IRepository<Bug> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Bug>> GetAllBugs()
    {
        return await _repository.GetAll();
    }

    // POST: create new bug
    // PATCH: update bug
    // GET: get bug by id
    // DELETE: delete bug by id
}

