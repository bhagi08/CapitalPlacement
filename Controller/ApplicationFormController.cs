using Microsoft.AspNetCore.Mvc;
using Jobs.Service;
using Jobs.Models;

namespace Jobs.Controller;

[ApiController]
[Route("api/[controller]")]
public class ApplicationFormController : ControllerBase
{
    private readonly ApplicationFormService _applicationFormService;

    public ApplicationFormController(ApplicationFormService applicationService)
    {
        _applicationFormService = applicationService;
    }

    // GET: api/ApplicationForm
    [HttpGet]
    public ActionResult<List<ApplicationForm>> Get() =>
        _applicationFormService.Get();

    // GET: api/ApplicationForm/{id}
    [HttpGet("{id}", Name = "GetApplicationForm")]
    public ActionResult<ApplicationForm> Get(string id)
    {
        var applicationForm = _applicationFormService.Get(id);

        if (applicationForm == null)
        {
            return NotFound();
        }

        return applicationForm;
    }

    // POST: api/ApplicationForm
    [HttpPost]
    public ActionResult<ApplicationForm> Create(ApplicationForm applicationForm)
    {
        _applicationFormService.Create(applicationForm);

        return CreatedAtRoute("GetApplication", new { id = applicationForm.formId.ToString() }, applicationForm);
    }

    // PUT: api/ApplicationForm/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, ApplicationForm applicationFormIn)
    {
        var applicationForm = _applicationFormService.Get(id);

        if (applicationForm == null)
        {
            return NotFound();
        }
        applicationFormIn._id = applicationForm._id;
        _applicationFormService.Update(id, applicationFormIn);
        return NoContent();
    }

    // DELETE: api/ApplicationForm/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var applicationForm = _applicationFormService.Get(id);

        if (applicationForm == null)
        {
            return NotFound();
        }

        _applicationFormService.Remove(applicationForm.formId);

        return NoContent();
    }
}
