namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Tutorials;
using WebApi.Services;

[ApiController]
[Route("api/[controller]")]
public class TutorialsController : ControllerBase
{
    private ITutorialService _tutorialService;

    public TutorialsController(ITutorialService tutorialService)
    {
        _tutorialService = tutorialService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery(Name = "title")] string? title)
    {
        var tutorials = await _tutorialService.GetAll(title);
        return Ok(tutorials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tutorial = await _tutorialService.GetById(id);
        return Ok(tutorial);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTutorialRequest model)
    {   
        await _tutorialService.Create(model);
        return Ok(new { message = "Tutorial created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTutorialRequest model)
    {
        await _tutorialService.Update(id, model);
        return Ok(new { message = "Tutorial updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _tutorialService.Delete(id);
        return Ok(new { message = "Tutorial deleted" });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll()
    {
        await _tutorialService.DeleteAll();
        return Ok(new { message = "All Tutorials deleted" });
    }
}