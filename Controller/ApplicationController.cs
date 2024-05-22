using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Jobs.Service;
using Jobs.Models;
namespace Jobs.Controller;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ApplicationService _applicationService;

    public ApplicationController(ApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    // GET: api/Application
    [HttpGet]
    public ActionResult<List<Application>> Get() =>
        _applicationService.Get();

    // GET: api/Application/{id}
    [HttpGet("{id}", Name = "GetApplication")]
    public ActionResult<Application> Get(string id)
    {
        var application = _applicationService.Get(id);

        if (application == null)
        {
            return NotFound();
        }

        return application;
    }

    // POST: api/Application
    [HttpPost]
    public ActionResult<Application> Create(Application application)
    {
        _applicationService.Create(application);

        return CreatedAtRoute("GetApplication", new { id = application.applicationId.ToString() }, application);
    }

    // PUT: api/Application/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, Application applicationIn)
    {
        var application = _applicationService.Get(id);

        if (application == null)
        {
            return NotFound();
        }

         applicationIn._id = application._id;    
        _applicationService.Update(id, applicationIn);

        return NoContent();
    }

    // DELETE: api/Application/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var application = _applicationService.Get(id);

        if (application == null)
        {
            return NotFound();
        }

        _applicationService.Remove(application.applicationId);

        return NoContent();
    }
}
