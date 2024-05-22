using Microsoft.AspNetCore.Mvc;
using Jobs.Service;
using Jobs.Models;

namespace Jobs.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProgramsController : ControllerBase
{
    private readonly ProgramsService _programsService;

    public ProgramsController(ProgramsService programsService)
    {
        _programsService = programsService;
    }

    // GET: api/Programs
    [HttpGet]
    public ActionResult<List<Programs>> Get() =>
        _programsService.Get();

    // GET: api/Programs/{id}
    [HttpGet("{id}", Name = "GetPrograms")]
    public ActionResult<Programs> Get(string id)
    {
        var programs = _programsService.Get(id);

        if (programs == null)
        {
            return NotFound();
        }

        return programs;
    }

    // POST: api/Programs
    [HttpPost]
    public ActionResult<Programs> Create(Programs programs)
    {
        _programsService.Create(programs);

        return CreatedAtRoute("GetPrograms", new { id = programs.programId.ToString() }, programs);
    }

    // PUT: api/Programs/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, Programs programsIn)
    {
        var programs = _programsService.Get(id);

        if (programs == null)
        {
            return NotFound();
        }
        programsIn._id = programs._id;
        _programsService.Update(id, programsIn);

        return NoContent();
    }

    // DELETE: api/Programs/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var programs = _programsService.Get(id);

        if (programs == null)
        {
            return NotFound();
        }

        _programsService.Remove(programs.programId);

        return NoContent();
    }
}
