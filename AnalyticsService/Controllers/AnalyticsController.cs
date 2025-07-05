using AnalyticsService.Model;
using AnalyticsService.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _service;

    public AnalyticsController(IAnalyticsService service)
        => _service = service;

    [HttpPost]
    public async Task<IActionResult> Insert(AnalyticsModel dto)
    {
        try
        {
            await _service.InsertEventAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}